using Godot;
using System;

public partial class Debris : Node2D
{
	[Export]
	public float RotationSpeed = 3.14f; 
	
	private Sprite2D sprite = null;

	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("Sprite2D");
	}

	public override void _Process(double delta)
	{
		if(sprite != null)
			sprite.Rotation += RotationSpeed * (float)delta;
	}
}
