
// Core communication between systems and important stuff.

// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/10/19 04:29 PM



using UnityEngine;
using System.Collections;


public class Game : MonoBehaviour
{
	// The Player is the game object with the tag Player.
	private static Transform _player;
	public static Transform player
	{
		get
		{
			if (_player == null)
			{
				GameObject go = GameObject.FindGameObjectWithTag(Tag.Player);
				if (go)
					_player = go.transform;
			}

			return _player;
		}
	}


	// Camera2D
	private static Camera2D _camera2d;
	public static Camera2D camera2D
	{
		get
		{
			if (_camera2d == null)
				_camera2d = GameObject.FindObjectOfType<Camera2D>();

			return _camera2d;
		}
	}


	// Sound library
	private static Sounds _sounds;
	public static Sounds sounds
	{
		get
		{
			if (_sounds == null)
				_sounds = GameObject.FindObjectOfType<Sounds>();

			return _sounds;
		}
	}


	// Color library
	private static Palette _palette;
	public static Palette palette
	{
		get
		{
			if (_palette == null)
				_palette = GameObject.FindObjectOfType<Palette>();

			return _palette;
		}
	}


	// Time control
	private static Timeflux _timeflux;
	public static Timeflux timeflux
	{
		get
		{
			if (_timeflux == null)
				_timeflux = GameObject.FindObjectOfType<Timeflux>();

			return _timeflux;
		}
	}


	// Gamepad + InControl
	private static GamepadInControl _gamepadInControl;
	public static GamepadInControl gamepadInControl
	{
		get
		{
			if (_gamepadInControl == null)
				_gamepadInControl = GameObject.FindObjectOfType<GamepadInControl>();

			return _gamepadInControl;
		}
	}
}
