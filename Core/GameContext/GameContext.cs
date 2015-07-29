
// Andrés Villalobos | andresalvivar@gmail.com | twitter.com/matnesis
// 2015/07/27 06:50:55 PM

// GameContext is everything.


using UnityEngine;
using System.Collections;


public class GameContext : MonoBehaviour
{
	// Player the game object the tag Player.
	private static Transform player;
	public static Transform Player
	{
		get
		{
			if (player == null)
			{
				GameObject go = GameObject.FindGameObjectWithTag(Tag.Player);
				if (go)
					player = go.transform;
			}

			return player;
		}
	}


	private static GameContext instance;
	public static GameContext g
	{
		get
		{
			if (instance == null)
				instance = GameObject.FindObjectOfType<GameContext>();

			return instance;
		}
	}
}
