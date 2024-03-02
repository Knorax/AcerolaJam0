using Godot;
using System;
using System.Diagnostics;

public partial class Controller : CharacterBody2D 
{
	[Export]
	public float MaxVelocity = 10.0f;

	[Export]
	public float Acceleration = 100.0f;

	[Export]
	public float Deceleration = 100.0f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 direction = Input.GetVector("left", "right", "up", "down").Normalized();

		if(direction != Vector2.Zero)
			Velocity = Velocity.MoveToward(direction * MaxVelocity, Acceleration * (float)delta);
		else
			Velocity = Velocity.MoveToward(Vector2.Zero, Deceleration * (float)delta);
		
		MoveAndSlide();
	}
}
