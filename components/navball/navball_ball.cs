using Godot;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using KRPC.Schema.KRPC;
using System;
using System.Net;
public partial class navball_ball : CsgSphere3D
{
	private KRPCManager kRPC;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		kRPC = (KRPCManager) GetNode("/root/KrpcManager");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		RotationDegrees = new Vector3(kRPC.pitchStream.Get(), -1 * kRPC.headingStream.Get() + 180, kRPC.rollStream.Get());
	}
}
