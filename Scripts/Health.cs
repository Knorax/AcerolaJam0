using Godot;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class Health : Node
{
	private const int DEFAULT_HEALTH = 100;

	[Export]
	public int MaxHealth = DEFAULT_HEALTH;

	[Export]
	public int HealthPoints = DEFAULT_HEALTH;
	
	[Signal]
	public delegate void DiedEventHandler();
	
	public void TakeDamage(int amount)
	{
		if(HealthPoints - amount <= 0) {
			HealthPoints = 0;
			EmitSignal(SignalName.Died);
			Debug.Print("Ouf!");
		}
		else {
			HealthPoints -= amount;
			Debug.Print("Urg!");
		}
	}
	
}
