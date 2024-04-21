using System;
using System.Collections.Generic;
using UnityEngine;

public class ManagePlayer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _players;
    

    public Player ChoosePlayer;

    private void Start()
    {
        _players[0].SetActive(false);
        _players[ChoosePlayerController.CurrentPosition].SetActive(true);
        Camera.main.transform.parent = _players[ChoosePlayerController.CurrentPosition].transform;
        Camera.main.transform.localPosition = new Vector3(0f, 0f, -10f);
        ChoosePlayer = _players[ChoosePlayerController.CurrentPosition].GetComponent<Player>();
    }
    
}
