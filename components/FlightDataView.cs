using Godot;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public partial class FlightDataView : GridContainer
{
	private KRPCManager kRPC;

	private Label speedLabel;
	private Label altLabel;
	private Label latLabel;
	private Label longLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		kRPC = (KRPCManager) GetNode("/root/KrpcManager");
		speedLabel = new Label();
		altLabel = new Label();
		latLabel = new Label();
		longLabel = new Label();

		AddChild(speedLabel);
		AddChild(altLabel);
		AddChild(latLabel);
		AddChild(longLabel);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var flight = kRPC.flightStream.Get();
		speedLabel.Text = String.Format("Velocity: {0:0.00}m/s", flight.Speed);
		altLabel.Text = String.Format("Altitude: {0:0.00}m ({1:0.00}m above sea)", flight.SurfaceAltitude, flight.BedrockAltitude);
		latLabel.Text = String.Format("Latitude: {0:0.00} degrees", flight.Latitude);
		longLabel.Text = String.Format("Longtitude: {0:0.00} degrees", flight.Longitude);
	}
}
