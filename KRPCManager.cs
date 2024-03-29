using Godot;
using System.Net;
using KRPC.Client;
using KRPC.Client.Services.KRPC;
using KRPC.Client.Services.SpaceCenter;

using System;

public partial class KRPCManager : Godot.Node
{
	public string ip = "127.0.0.1";
	public Connection krpcConnection;
	public KRPC.Client.Services.SpaceCenter.Service spaceCenter;
	public KRPC.Client.Services.SpaceCenter.Vessel currentVessel;
	public Stream<Flight> flightStream;
	public Stream<float> pitchStream;
	public Stream<float> headingStream;
	public Stream<float> rollStream;
	public Stream<Orbit> orbitStream;
	public Stream<double> orbitalVelocityStream;

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
		flightStream = krpcConnection.AddStream(() => currentVessel.Flight(currentVessel.Orbit.Body.ReferenceFrame));
		pitchStream = krpcConnection.AddStream(() => flight.Pitch);
		headingStream = krpcConnection.AddStream(() => flight.Heading);
		rollStream = krpcConnection.AddStream(() => flight.Roll);
		orbitStream = krpcConnection.AddStream(() => currentVessel.Orbit);
		orbitalVelocityStream = krpcConnection.AddStream(() => currentVessel.Flight(currentVessel.Orbit.Body.NonRotatingReferenceFrame).Speed);
	}


	public override void _ExitTree()
	{
		base._ExitTree();
		krpcConnection.Dispose();
	}

}
