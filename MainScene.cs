using Godot;
using System;
using System.Diagnostics;

public partial class MainScene : Godot.Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionPressed("up"))
			Debug.Print("Up pressed!");
		if(Input.IsActionPressed("down"))
			Debug.Print("Down pressed!");
		if(Input.IsActionPressed("right"))
			Debug.Print("Right pressed!");
		if(Input.IsActionPressed("left"))
			Debug.Print("Left pressed!");
	}
}
