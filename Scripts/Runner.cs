using Godot;
using System;
using System.Diagnostics;

public partial class Runner : Node2D
{
	[Export]
	public float InitialSpeed = 50.0f;

	[Export]
	public float WalkTimeSeconds = 1.0f;
	
	[Export]
	public float RunAcceleration = 200.0f;
	
	[Export]
	public double RotationSpeed = Math.PI/4.0f;
	
	CharacterBody2D player = null;

	MoveStraight movementController = null;

	Timer timer = null;
	
	bool sprinting = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bool status = getMovementController();
		status &= getPlayer();
		if(!status)
			return;

		initRunningCountdownTimer();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(!sprinting || movementController == null || player == null)
			return;
		
		movementController.Speed += RunAcceleration * (float)delta;
		
		double rotationToPlayer = GlobalPosition.DirectionTo(player.Position).Angle();
		if(!Mathf.IsZeroApprox(rotationToPlayer))
			Rotation = Rotation + (float)(delta * (rotationToPlayer > 0.0f ? RotationSpeed : -RotationSpeed));
	}
	
	private void startRunning()
	{
		Debug.Print("Start Tunning!");

		if(player != null)
			Rotation = GlobalPosition.DirectionTo(player.Position).Angle();

		sprinting = true;
	}
	
	private bool getMovementController()
	{
		movementController = GetNode<MoveStraight>("MoveStraight");
		if(movementController == null)
		{
			Debug.Print("NO MOVEMENT CONTROLLER FOUND IN RUNNER");
			return false;
		}

		movementController.Speed = InitialSpeed;
		return true;
	}

	private bool getPlayer()
	{
		var nodes = GetTree().GetNodesInGroup("Player");

		if(nodes == null)
		{
			Debug.Print("NO PLAYER FOUND BY RUNNER");
			return false;
		}
		player = (CharacterBody2D)nodes[0];
		return true;
	}
	
	private void initRunningCountdownTimer()
	{
		timer = new Timer();
		timer.WaitTime = WalkTimeSeconds;
		timer.OneShot = true;
		timer.Autostart = true;
		AddChild(timer);
		timer.Connect("timeout", new Callable(this, "startRunning"));
	}
}
