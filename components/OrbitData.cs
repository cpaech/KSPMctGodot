using Godot;
using System;

public partial class OrbitData : GridContainer
{

	private KRPCManager kRPC;
	private Label bodyLabel;
	private Label speedLabel;
	private Label apLabel;
	private Label peLabel;
	private Label incLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		kRPC = (KRPCManager)GetNode("/root/KrpcManager");
		bodyLabel = new Label();
		speedLabel = new Label();
		apLabel = new Label();
		peLabel = new Label();
		incLabel = new Label();

		AddChild(bodyLabel);
		AddChild(speedLabel);
		AddChild(apLabel);
		AddChild(peLabel);
		AddChild(incLabel);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		var orbit = kRPC.orbitStream.Get();
		bodyLabel.Text = String.Format("Central Body: {0:0.00}", orbit.Body.Name);
		speedLabel.Text = String.Format("Velocity: {0:0.00}m/s", kRPC.orbitalVelocityStream.Get());
		apLabel.Text = String.Format("Apoapsis: {0:0.00}m ({1:0.00}m from center of mass)", orbit.ApoapsisAltitude, orbit.Apoapsis);
		peLabel.Text = String.Format("Periapsis: {0:0.00}m ({1:0.00}m from center of mass)", orbit.PeriapsisAltitude, orbit.Periapsis);
		incLabel.Text = String.Format("Inclination: {0:0.00} degrees", (orbit.Inclination/(Math.PI*2))*360);
	}
}
