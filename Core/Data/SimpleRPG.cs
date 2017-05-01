
// Reactive data for simple RPG behaviours.

// @matnesis
// 2016/06/20 07:32 PM


using UnityEngine;
using matnesis.Reactive;

[ReactiveInEditMode]
public class SimpleRPG : MonoBehaviour
{
    [Header("Stats")]
    public ReactiveInt hp = new ReactiveInt(3);
    public ReactiveInt stamina = new ReactiveInt(5);
    public ReactiveInt coins = new ReactiveInt(0);

    [Header("Combat")]
    public ReactiveInt damage = new ReactiveInt(1);
    public ReactiveInt knockback = new ReactiveInt(1);
}
