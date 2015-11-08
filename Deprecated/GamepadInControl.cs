
// Manager that holds the connection between InControl and Action events.

// 2015/10/19 03:47 PM


using UnityEngine;
using InControl;
using System;


public class GamepadInControl : MonoBehaviour
{
	// Actions
	public Action OnJump;
	public Action OnActivate;
	public Action OnDash;
	public Action OnAttack;
	public Action OnAttackRelease;
	public Action OnCommand;

	public InControlActionSet currentPlayer;


	// Movement vector
	public Vector2 Movement
	{
		get
		{
			return currentPlayer != null ? currentPlayer.Movement.Value : Vector2.zero;
		}
	}


	void Start()
	{
		currentPlayer = new InControlActionSet();

		// Movement (Axis + Dpad + WASD + Keys)
		currentPlayer.Left.AddDefaultBinding(Key.A);
		currentPlayer.Left.AddDefaultBinding(Key.LeftArrow);
		currentPlayer.Left.AddDefaultBinding(InputControlType.DPadLeft);
		currentPlayer.Left.AddDefaultBinding(InputControlType.LeftStickLeft);

		currentPlayer.Right.AddDefaultBinding(Key.D);
		currentPlayer.Right.AddDefaultBinding(Key.RightArrow);
		currentPlayer.Right.AddDefaultBinding(InputControlType.DPadRight);
		currentPlayer.Right.AddDefaultBinding(InputControlType.LeftStickRight);

		currentPlayer.Up.AddDefaultBinding(Key.W);
		currentPlayer.Up.AddDefaultBinding(Key.UpArrow);
		currentPlayer.Up.AddDefaultBinding(InputControlType.DPadUp);
		currentPlayer.Up.AddDefaultBinding(InputControlType.LeftStickUp);

		currentPlayer.Down.AddDefaultBinding(Key.S);
		currentPlayer.Down.AddDefaultBinding(Key.DownArrow);
		currentPlayer.Down.AddDefaultBinding(InputControlType.DPadDown);
		currentPlayer.Down.AddDefaultBinding(InputControlType.LeftStickDown);


		// Actions
		currentPlayer.Jump.AddDefaultBinding(Key.Space);
		currentPlayer.Jump.AddDefaultBinding(InputControlType.Action1);

		currentPlayer.Activate.AddDefaultBinding(Key.E);
		currentPlayer.Activate.AddDefaultBinding(InputControlType.Action3);

		currentPlayer.Dash.AddDefaultBinding(Key.V);
		currentPlayer.Dash.AddDefaultBinding(InputControlType.Action4);

		currentPlayer.Attack.AddDefaultBinding(Key.V);
		currentPlayer.Attack.AddDefaultBinding(InputControlType.Action4);


		// Menu
		currentPlayer.Command.AddDefaultBinding(Key.Escape);
		currentPlayer.Command.AddDefaultBinding(InputControlType.Command);
	}


	void Update()
	{
		// Actions
		if (currentPlayer.Jump.WasPressed && OnJump != null)
			OnJump();

		if (currentPlayer.Activate.WasPressed && OnActivate != null)
			OnActivate();

		if (currentPlayer.Dash.WasPressed && OnDash != null)
			OnDash();

		if (currentPlayer.Attack.WasPressed && OnAttack != null)
			OnAttack();

		if (currentPlayer.Attack.WasReleased && OnAttackRelease != null)
			OnAttackRelease();


		// Main menu
		if (currentPlayer.Command.WasPressed && OnCommand != null)
			OnCommand();


		// QuickInputTest();
	}


	void QuickInputTest()
	{
		// Movement
		if (currentPlayer.Left.WasPressed)
			Debug.Log("Left " + Time.time);

		if (currentPlayer.Right.WasPressed)
			Debug.Log("Right " + Time.time);

		if (currentPlayer.Up.WasPressed)
			Debug.Log("Up " + Time.time);

		if (currentPlayer.Down.WasPressed)
			Debug.Log("Down " + Time.time);


		// Actions
		if (currentPlayer.Jump.WasPressed)
			Debug.Log("Jump " + Time.time);

		if (currentPlayer.Activate.WasPressed)
			Debug.Log("Activate " + Time.time);

		if (currentPlayer.Dash.WasPressed)
			Debug.Log("Dash " + Time.time);

		if (currentPlayer.Attack.WasPressed)
			Debug.Log("Attack " + Time.time);

		if (currentPlayer.Attack.WasReleased)
			Debug.Log("Attack Release" + Time.time);


		// Menu
		if (currentPlayer.Command.WasPressed)
			Debug.Log("Command " + Time.time);
	}
}
