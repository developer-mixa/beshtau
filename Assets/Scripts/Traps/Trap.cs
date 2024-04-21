using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Trap : MonoBehaviour
{

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _trapClip;

    private void Awake()
    {
        _audioSource = FindObjectOfType<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnCollider(other.gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnCollider(other.gameObject);
    }

    private void OnCollider(GameObject other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            _audioSource.PlayOneShot(_trapClip);
            player.IncreaseHealth();
        }
    }


}
