
// Generic InControl PlayerActionSet.

// 2015/10/19 04:41 PM


using InControl;


public class InControlActionSet : PlayerActionSet
{
	// Joystick
	public PlayerAction Left;
	public PlayerAction Right;
	public PlayerAction Up;
	public PlayerAction Down;
	public PlayerTwoAxisAction Movement;

	// Basic actions
	public PlayerAction Jump;
	public PlayerAction Dash;
	public PlayerAction Attack;
	public PlayerAction Activate;

	// Menu
	public PlayerAction Command;


	public InControlActionSet()
	{
		// Joystick
		Left = CreatePlayerAction("MoveLeft");
		Right = CreatePlayerAction("MoveRight");
		Up = CreatePlayerAction("MoveUp");
		Down = CreatePlayerAction("MoveDown");

		Movement = CreateTwoAxisPlayerAction(Left, Right, Down, Up);


		// Actions
		Jump = CreatePlayerAction("Jump");
		Dash = CreatePlayerAction("Dash");
		Attack = CreatePlayerAction("Attack");
		Activate = CreatePlayerAction("Activate");


		// Menu
		Command = CreatePlayerAction("Command");
	}
}
