using Godot;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using KRPC.Schema.KRPC;
using System;
using System.Net;
public partial class navball_ball : CsgSphere3D
{
	[Export]
	public Godot.Node3D prograde_marker;
	private KRPCManager kRPC;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		kRPC = (KRPCManager) GetNode("/root/KrpcManager");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//TODO disable Markers when under Ball
		// Turns out that for some random reason it is faster to use seperate streams for pitch, heading, roll but not for other flight data? Why tho?
		RotationDegrees = new Vector3(kRPC.pitchStream.Get(), -1 * kRPC.headingStream.Get() + 180, kRPC.rollStream.Get());
		var prograde = kRPC.currentVessel.Flight(kRPC.currentVessel.ReferenceFrame ).Prograde;
		prograde_marker.Position = (new Vector3((float)prograde.Item1, (float)prograde.Item2, (float)prograde.Item3) * 1.1f).Rotated(new Vector3(1, 0, 0), 0.5f * (float)Math.PI) ;
	}
}
