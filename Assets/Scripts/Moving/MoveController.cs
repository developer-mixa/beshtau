using System;
using UnityEngine;

[RequireComponent(typeof(Player), typeof(PlayerUI))]
public class MoveController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private MoveButton leftButton;
    [SerializeField] private MoveButton rightButton;
    [SerializeField] private MoveButton upButton;
    private Player _player;
    private PlayerUI _playerUI;
    private Transform _playerTransform;
    private Rigidbody2D _playerRig;
    
    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerTransform = GetComponent<Transform>();
        _playerRig = GetComponent<Rigidbody2D>();
        _playerUI = GetComponent<PlayerUI>();
    }

    private void FixedUpdate()
    {
        ControlWalkAnimation(false);
        if(leftButton.OnDown && rightButton.OnDown) return;
        
        if (leftButton.OnDown)
        {
            Go(MoveDirection.LEFT);
        } else if (rightButton.OnDown)
        {
            Go(MoveDirection.RIGHT);
        }
        else
        {
            ControlWalkAnimation(false);
        }
        
    }

    private void OnEnable()
    {
        _player.OnUp += ListenOnUp;
    }
    
    private void OnDisable()
    {
        _player.OnUp -= ListenOnUp;
    }

    private void ListenOnUp(bool isOnUp)
    {
        _playerUI.DisplayJump(isOnUp);
    }
    
    private void Go(MoveDirection moveDirection)
    {
        var direction = moveDirection == MoveDirection.LEFT ? -1 : 1f;
        _playerRig.AddForce(new Vector3(direction, 0, 0), ForceMode2D.Force);
        _playerTransform.position += new Vector3(direction,0f, 0f) * _speed * Time.fixedDeltaTime;
        _playerUI.DisplayTurnDirection(moveDirection);
        ControlWalkAnimation(true);
    }

    private void ControlWalkAnimation(bool walking)
    {
        _playerUI.DisplayWalkAnimation(walking);
    }
    

    public void Jump()
    {
        if(!_player.isOnGround) return;
        ControlWalkAnimation(false);
       _playerRig.AddForce(new Vector2(0, _jumpPower), ForceMode2D.Impulse);
    }
    
}
