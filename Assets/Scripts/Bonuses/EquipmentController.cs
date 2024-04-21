using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EquipmentController : MonoBehaviour, Bonus
{
    [SerializeField] private string _information;
    [SerializeField] private Sprite _sprite;
    
    private EquipmentUI _equipmentUI;

    private void Awake()
    {
        _equipmentUI = GetComponent<EquipmentUI>();
    }

    public void Get()
    {
        _equipmentUI.Present(_information, _sprite);
        Destroy(gameObject);
    }
}
