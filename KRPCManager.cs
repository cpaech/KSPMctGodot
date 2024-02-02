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
	}

    public override void _ExitTree()
    {
        base._ExitTree();
		krpcConnection.Dispose();
    }

}
