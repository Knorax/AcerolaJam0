using Godot;
using System;
using System.Diagnostics;

public partial class Collider : Area2D
{
	[Export]
	public int Damage = 1;

	private void OnBodyEntered(Node2D body)
	{
		Debug.Print("BodyEntered");
		if(body.HasNode("Health"))
		{
			body.GetNode<Health>("Health").TakeDamage(Damage);
			GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
			GetParent().QueueFree();
		}
		
	}
}
