
// Manager that holds the connection between InControl and Action events.

// 2015/10/19 03:47 PM


using UnityEngine;
using InControl;
using System;


public class GamepadInControl : MonoBehaviour
{
	private GamepadInControlActionSet _playerInControlActions;

	// Actions
	public Action OnJump;
	public Action OnActivate;
	public Action OnDash;
	public Action OnAttack;
	public Action OnCommand;


	void Start()
	{
		_playerInControlActions = new GamepadInControlActionSet();


		// Movement (Axis + Dpad + WASD + Keys)
		_playerInControlActions.Left.AddDefaultBinding(Key.A);
		_playerInControlActions.Left.AddDefaultBinding(Key.LeftArrow);
		_playerInControlActions.Left.AddDefaultBinding(InputControlType.DPadLeft);
		_playerInControlActions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);

		_playerInControlActions.Right.AddDefaultBinding(Key.D);
		_playerInControlActions.Right.AddDefaultBinding(Key.RightArrow);
		_playerInControlActions.Right.AddDefaultBinding(InputControlType.DPadRight);
		_playerInControlActions.Right.AddDefaultBinding(InputControlType.LeftStickRight);

		_playerInControlActions.Up.AddDefaultBinding(Key.W);
		_playerInControlActions.Up.AddDefaultBinding(Key.UpArrow);
		_playerInControlActions.Up.AddDefaultBinding(InputControlType.DPadUp);
		_playerInControlActions.Up.AddDefaultBinding(InputControlType.LeftStickUp);

		_playerInControlActions.Down.AddDefaultBinding(Key.S);
		_playerInControlActions.Down.AddDefaultBinding(Key.DownArrow);
		_playerInControlActions.Down.AddDefaultBinding(InputControlType.DPadDown);
		_playerInControlActions.Down.AddDefaultBinding(InputControlType.LeftStickDown);


		// Actions
		_playerInControlActions.Jump.AddDefaultBinding(Key.Space);
		_playerInControlActions.Jump.AddDefaultBinding(InputControlType.Action1);

		_playerInControlActions.Activate.AddDefaultBinding(Key.E);
		_playerInControlActions.Activate.AddDefaultBinding(InputControlType.Action3);

		_playerInControlActions.Dash.AddDefaultBinding(Key.V);
		_playerInControlActions.Dash.AddDefaultBinding(InputControlType.Action4);

		_playerInControlActions.Attack.AddDefaultBinding(Key.V);
		_playerInControlActions.Attack.AddDefaultBinding(InputControlType.Action4);


		// Menu
		_playerInControlActions.Command.AddDefaultBinding(Key.Escape);
		_playerInControlActions.Command.AddDefaultBinding(InputControlType.Command);
	}


	void Update()
	{
		// Actions
		if (_playerInControlActions.Jump.WasPressed && OnJump != null)
			OnJump();

		if (_playerInControlActions.Activate.WasPressed && OnActivate != null)
			OnActivate();

		if (_playerInControlActions.Dash.WasPressed && OnDash != null)
			OnDash();

		if (_playerInControlActions.Attack.WasPressed && OnDash != null)
			OnAttack();


		// Main menu
		if (_playerInControlActions.Command.WasPressed && OnCommand != null)
			OnCommand();


		// QuickInputTest();
	}


	void QuickInputTest()
	{
		// Movement
		if (_playerInControlActions.Left.WasPressed)
			Debug.Log("Left " + Time.time);

		if (_playerInControlActions.Right.WasPressed)
			Debug.Log("Right " + Time.time);

		if (_playerInControlActions.Up.WasPressed)
			Debug.Log("Up " + Time.time);

		if (_playerInControlActions.Down.WasPressed)
			Debug.Log("Down " + Time.time);


		// Actions
		if (_playerInControlActions.Jump.WasPressed)
			Debug.Log("Jump " + Time.time);

		if (_playerInControlActions.Activate.WasPressed)
			Debug.Log("Activate " + Time.time);

		if (_playerInControlActions.Dash.WasPressed)
			Debug.Log("Dash " + Time.time);

		if (_playerInControlActions.Dash.WasPressed)
			Debug.Log("Attack " + Time.time);


		// Menu
		if (_playerInControlActions.Command.WasPressed)
			Debug.Log("Command " + Time.time);
	}
}
