using Godot;
using System;

namespace FirstActionRPG.scenes
{
	public partial class Player : CharacterBody2D
	{
		private const float Speed = 100.0f;

		public override void _PhysicsProcess(double delta)
		{
			PlayerMovement(delta);
		}

		private void PlayerMovement(double delta)
		{
			var velocity = Velocity;
			
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
}

