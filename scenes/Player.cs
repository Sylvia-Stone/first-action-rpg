using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 100.0f;

	public override void _PhysicsProcess(double delta)
	{
		PlayerMovement(delta);
	}

	public void PlayerMovement(double delta)
	{
		Vector2 velocity = Velocity;

		if (Input.IsActionPressed("ui_right"))
		{
			velocity.X = Speed;
			velocity.Y = 0;
		}
		else if (Input.IsActionPressed("ui_left"))
		{
			velocity.X = -Speed;
			velocity.Y = 0;
		}
		else if (Input.IsActionPressed("ui_up"))
		{
			velocity.X = 0;
			velocity.Y = -Speed;
		}
		else if (Input.IsActionPressed("ui_down"))
		{
			velocity.X = 0;
			velocity.Y = Speed;
		}

		Velocity = velocity;

		MoveAndSlide();
	}
}
