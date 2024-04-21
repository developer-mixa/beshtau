using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    
    public void OnPointerUp(PointerEventData eventData)
    {
        FindObjectOfType<MoveController>().Jump();
    }

    public void OnPointerDown(PointerEventData eventData) { }
}
