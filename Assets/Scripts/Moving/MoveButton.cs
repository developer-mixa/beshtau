using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _onDown;
    public bool OnDown => _onDown;
    
    public void OnPointerDown(PointerEventData data)
    {
        _onDown = true;
    } 

    public void OnPointerUp(PointerEventData data)
    {
        _onDown = false;
    } 
    
}
