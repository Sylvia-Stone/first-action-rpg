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
			var velocity = Velocity;
			
			if (Input.IsActionPressed("ui_right"))
			{
				_currentDirection = Direction.Right;
				velocity.X = Speed;
				velocity.Y = 0;
			}
			else if (Input.IsActionPressed("ui_left"))
			{
				_currentDirection = Direction.Left;
				velocity.X = -Speed;
				velocity.Y = 0;
			}
			else if (Input.IsActionPressed("ui_up"))
			{
				_currentDirection = Direction.Up;
				velocity.X = 0;
				velocity.Y = -Speed;
			}
			else if (Input.IsActionPressed("ui_down"))
			{
				_currentDirection = Direction.Down;
				velocity.X = 0;
				velocity.Y = Speed;
			}
			else
			{
				velocity.X = 0;
				velocity.Y = 0;
			}
			
			Velocity = velocity;
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

