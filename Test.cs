using Godot;
using System.Net;
using KRPC.Client;
using KRPC.Client.Services.KRPC;

using System;

public partial class Test : Node
{
	[Export]
	public string ip = "127.0.0.1";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Test");
		using (var connection = new Connection(
				   name: "My Example Program",
				   address: IPAddress.Parse(ip),
				   rpcPort: 5000,
				   streamPort: 5001)) {
			var krpc = connection.KRPC();
			GD.Print(krpc.GetStatus().Version);}
	}

	public void GetTest() {
		GD.Print("It WORKS!");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
