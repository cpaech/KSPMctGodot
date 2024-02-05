using Godot;
using System;

public partial class FlightDataView : GridContainer
{


	public Label altLabel;
	public Label latLabel;
	public Label longLabel;
	private KRPCManager kRPC;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		altLabel = GetChild<Label>(1);
		latLabel = GetChild<Label>(3);
		longLabel = GetChild<Label>(5);
		kRPC = (KRPCManager) GetNode("/root/KrpcManager");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var flight = kRPC.flightStream.Get();
		altLabel.Text = flight.SurfaceAltitude.ToString();
		latLabel.Text = flight.Latitude.ToString();
		longLabel.Text = flight.Longitude.ToString();

	}
}
