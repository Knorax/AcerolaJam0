using Godot;
using System;
using System.Diagnostics;
using Godot.Collections;

public partial class MainScene : Godot.Node2D
{
	private const float DEBRIS_MAX_ROT_SPEED = 3.14f;

	[Export]
	public PackedScene DebrisType {get; set;}

	private Timer timer = null;
	private Array<Node> SpawnPoints = null;

	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = new Timer();
		timer.WaitTime = 1.0f;
		timer.OneShot = false;
		timer.Autostart = true;

		AddChild(timer);
		timer.Connect("timeout", new Callable(this, "SpawnDebris"));
		
		SpawnPoints = GetTree().GetNodesInGroup("SpawnPoints");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void SpawnDebris()
	{
		Debug.Print("Spawning Debris");
		foreach(Node spawnPoint in SpawnPoints)
		{
			Node2D spawnPoint2D = (Node2D) spawnPoint;

			Debris debris = DebrisType.Instantiate<Debris>();
			debris.Position = spawnPoint2D.Position;
			debris.Rotation = spawnPoint2D.Rotation;
			debris.SetMeta("Speed", 200.0f);
			debris.RotationSpeed = Math.Clamp(DEBRIS_MAX_ROT_SPEED * 2 * GD.Randf() - DEBRIS_MAX_ROT_SPEED, -DEBRIS_MAX_ROT_SPEED, DEBRIS_MAX_ROT_SPEED);

			AddChild(debris);
		}
	}
}
