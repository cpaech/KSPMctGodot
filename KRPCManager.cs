using Godot;
using System.Net;
using KRPC.Client;
using KRPC.Client.Services.KRPC;
using KRPC.Client.Services.SpaceCenter;

using System;

public partial class KRPCManager : Godot.Node
{
	public string ip = "192.168.179.2";
	public Connection krpcConnection;
	public KRPC.Client.Services.SpaceCenter.Service spaceCenter;
	public KRPC.Client.Services.SpaceCenter.Vessel currentVessel;

	public Stream<float> pitchStream;
	public Stream<float> headingStream;
	public Stream<float> rollStream;
	public Stream<double> altStream;
	public Stream<double> latStream;
	public Stream<double> longStream;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		krpcConnection = new Connection(
				   name: "My Example Program",
				   address: IPAddress.Parse(ip),
				   rpcPort: 5000,
				   streamPort: 5001);
		spaceCenter = krpcConnection.SpaceCenter();
		currentVessel = spaceCenter.ActiveVessel;
		var flight = currentVessel.Flight();
		pitchStream = krpcConnection.AddStream(() => flight.Pitch);
		headingStream = krpcConnection.AddStream(() => flight.Heading);
		rollStream = krpcConnection.AddStream(() => flight.Roll);
		altStream = krpcConnection.AddStream(() => flight.SurfaceAltitude);
		latStream = krpcConnection.AddStream(() => flight.Latitude);
		longStream = krpcConnection.AddStream(() => flight.Longitude);

	}


	public override void _ExitTree()
	{
		base._ExitTree();
		krpcConnection.Dispose();
	}

}
