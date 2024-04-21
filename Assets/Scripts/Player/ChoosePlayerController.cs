
using System;
using UnityEngine;

public class ChoosePlayerController : MonoBehaviour
{
    [SerializeField] private ChoosePlayer _choosePlayer;
    [SerializeField] private ChoosePlayerView _choosePlayerView;

    public static int CurrentPosition = 0;
    
    private void OnEnable()
    {
        _choosePlayer.OnSetPosition += RegulatePersonFromPosition;
        CurrentPosition = 0;
    }
    
    private void OnDisable()
    {
        _choosePlayer.OnSetPosition -= RegulatePersonFromPosition;
    }

    private void RegulatePersonFromPosition(int currentPosition)
    {
        CurrentPosition = currentPosition;
        _choosePlayerView.RenderPerson(currentPosition);
    }
    
}
