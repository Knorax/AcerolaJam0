using Godot;
using System;
using System.Diagnostics;

public partial class MoveStraight : Node
{
	[Export]
	public Node2D ObjectToMove = null;
	[Export]
	public float Speed = 500.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(ObjectToMove != null && ObjectToMove.HasMeta("Speed"))
			Speed = (float)ObjectToMove.GetMeta("Speed");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(ObjectToMove != null)
			ObjectToMove.Position += ObjectToMove.Transform.X * Speed * (float)delta;
		else
			Debug.Print("NO OBJECT ATTACHED TO MoveStraight SCRIPT OBJECT");
	}
}
