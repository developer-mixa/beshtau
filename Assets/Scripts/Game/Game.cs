using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private ManagePlayer _player;
    [SerializeField] private List<GameObject> _removingObjects;

    private GameView _gameView;

    private void Awake()
    {
        _gameView = GetComponent<GameView>();
    }

    private void Start()
    {
        _player.ChoosePlayer.OnFinish += LoseGame;
    }

    private void OnDisable()
    {
        _player.ChoosePlayer.OnFinish -= LoseGame;
    }

    private void LoseGame()
    {
        RemoveAllObjects();
        _gameView.RenderLose();
    }

    public void RemoveAllObjects()
    {
        foreach (var removingObject in _removingObjects)
        {
            Destroy(removingObject);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
    
}
