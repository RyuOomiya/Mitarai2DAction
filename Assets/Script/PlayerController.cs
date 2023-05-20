using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    
    [Tooltip("着地の時用")] float _tmpPosY;
    [Tooltip("ジャンプ中のYpos")] float _jumpPosY;
    [SerializeField] float _jumpSpeed;
    [SerializeField] float _moveSpeed;
    [SerializeField,Tooltip("ジャンプ中の落下速度")] float _gravitySpeed;
    [Tooltip("InputValueの受け取り用")] float _movementValueX;
    public float JumpSpeed { get; set; }
    bool _isJump = false;

    private void Awake()
    {
        SetJumpSpeed();
    }

    void SetJumpSpeed()
    {
        JumpSpeed = _jumpSpeed;
        Debug.Log(JumpSpeed);
    }

    void OnJump(InputValue value)
    {
        SetJumpSpeed();
        _tmpPosY = transform.position.y;
        _isJump = true;
    }

    private void OnMove(InputValue value)
    {
        Vector2 movementVector = value.Get<Vector2>();
        _movementValueX = movementVector.x * _moveSpeed;
    }

    private void Update()
    {
        

        if(!_isJump)
        transform.position = new Vector2(transform.position.x + _movementValueX * Time.deltaTime, 1);
    }

    private void FixedUpdate()
    {
        if (_isJump)
        {
            transform.position = new Vector2(transform.position.x + _movementValueX * Time.deltaTime,
                transform.position.y + JumpSpeed * Time.deltaTime);
            JumpSpeed -= _gravitySpeed;
            if (transform.position.y <= _tmpPosY) _isJump = false;
        }
    }

}
