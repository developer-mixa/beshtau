using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GetDetailsModel _getDetailsModel;
    private Game _game;
    private FinishView _finishView;
    private bool _canTap;

    private void Awake()
    {
        _game = FindObjectOfType<Game>();
        _finishView = GetComponent<FinishView>();
    }
    
    private void FixedUpdate()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);

        bool playerNotNull = hit.collider.gameObject.GetComponent<Player>() != null;
        if (_canTap != playerNotNull)
        {
            _canTap = playerNotNull;
            _finishView.RenderTap(_canTap);
        }
    }
    
}
