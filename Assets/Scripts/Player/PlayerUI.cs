using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Sprite _jumpSprite;
    [SerializeField] private Sprite _groundSprite;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private const string WalkingState = "Base Layer.Walking";
    
    private Coroutine _walkCoroutine;
    
    //Use this because it's expensive to use _spriteRenderer.sprite == ...
    private bool _lastIsOnGround;
    private bool _lastUpState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DisplayTurnDirection(MoveDirection direction)
    {
        var isLeftDirection = direction == MoveDirection.LEFT;
        if(_spriteRenderer.flipX == isLeftDirection) return;
        _spriteRenderer.flipX = isLeftDirection;
    }

    public void DisplayJump(bool isUp)
    {
       // if(_lastIsOnGround == isUp) return;
        
        var showingSprite = isUp ? _jumpSprite : _groundSprite;
        _spriteRenderer.sprite = showingSprite;
        _lastIsOnGround = isUp;
    }

    public void DisplayWalkAnimation(bool walking)
    {
        if (!walking)
        {
            _spriteRenderer.sprite = _groundSprite;
            _animator.enabled = false;
        }
        else
        {
            _animator.enabled = true;
            _animator.Play(WalkingState);
        }
    }
}
