// Andrés Villalobos * twitter.com/matnesis * andresalvivar@gmail.com
// 2018/06/10 05:36 pm

using DG.Tweening;
using matnesis.FloatReference;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class Whiteboard : MonoBehaviour
{
	public Image image;
	public Color from;
	public Color to;
	public float duration;
	public Sequence tween;
}