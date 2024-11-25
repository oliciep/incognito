using Godot;
using System;

public partial class Main : Node2D
{
	private Vector2 _speed = new Vector2(400, 400); // Adjusted speed for both X and Y
	private Vector2 _velocity = new Vector2();

	private Sprite2D _sprite;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sprite = GetNode<Sprite2D>("Sprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_velocity = Vector2.Zero;

		if (Input.IsActionPressed("ui_right"))
		{
			_velocity.X += 1;
		}
		if (Input.IsActionPressed("ui_left"))
		{
			_velocity.X -= 1;
		}
		if (Input.IsActionPressed("ui_down"))
		{
			_velocity.Y += 1;
		}
		if (Input.IsActionPressed("ui_up"))
		{
			_velocity.Y -= 1;
		}

		_velocity = _velocity.Normalized() * _speed * (float)delta;
		_sprite.Position += _velocity;

		if (_sprite.Position.X > 1000)
		{
			_sprite.Position = new Vector2(-100, 350);
		}
	}
}