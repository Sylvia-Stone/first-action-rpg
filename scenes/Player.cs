using Godot;
using System;
using FirstActionRPG.Enums;

namespace FirstActionRPG.scenes
{
	public partial class Player : CharacterBody2D
	{
		private const float Speed = 100.0f;
		private Direction _currentDirection = Direction.None;

		public override void _PhysicsProcess(double delta)
		{
			PlayerMovement(delta);
		}

		private void PlayerMovement(double delta)
		{

			var input = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
			Velocity = input * Speed;
			
			if (input != Vector2.Zero)
			{
				if (input.X > 0) _currentDirection = Direction.Right;
				else if (input.X < 0) _currentDirection = Direction.Left;
				else if (input.Y > 0) _currentDirection = Direction.Down;
				else if (input.Y < 0) _currentDirection = Direction.Up;
			}
    
			// Call the rest of your movement logic.
			PlayAnimation();
			MoveAndSlide();
		}

		private void PlayAnimation()
		{
			AnimatedSprite2D animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
			var isMoving = Velocity.X != 0 || Velocity.Y != 0;

			switch (_currentDirection)
			{
				case Direction.Left:
				case Direction.Right:
					animatedSprite.FlipH = _currentDirection == Direction.Left;
					animatedSprite.Play(isMoving ? "walk-side" : "idle-side");
					break;
				case Direction.None:
				case Direction.Down:
					animatedSprite.Play(isMoving ? "walk-down" : "idle-down");
					break;
				case Direction.Up:
					animatedSprite.Play(isMoving ? "walk-up" : "idle-up");
					break;
			}
		}
	}
}

