
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class FinishButton : MonoBehaviour
{
    private Game _game;
    private GetDetailsModel _getDetailsModel;
    private FinishView _finishView;
    private Player _player;

    private void Start()
    {
        _game = FindObjectOfType<Game>();
        _getDetailsModel = FindObjectOfType<GetDetailsModel>();
        _finishView = FindObjectOfType<FinishView>();
        _player = FindObjectOfType<Player>();
    }
    
    
    public void FinishGame()
    {
        if (_getDetailsModel.CurrentComponentsCount >= _getDetailsModel.AllComponentsCount)
        {
            _game.RemoveAllObjects();
            _finishView.Win(_player.CurrentScore);
        }
    }

}
