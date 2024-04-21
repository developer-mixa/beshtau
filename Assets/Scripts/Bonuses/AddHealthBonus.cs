
using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class AddHealthBonus : MonoBehaviour, Bonus
{
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public void Get()
    {
        _player.AddHeart();
        Destroy(gameObject);
    }
}
