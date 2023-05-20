using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    
    [Tooltip("���n�̎��p")] float _tmpPosY;
    [Tooltip("�W�����v����Ypos")] float _jumpPosY;
    [SerializeField] float _jumpSpeed;
    [SerializeField] float _moveSpeed;
    [SerializeField,Tooltip("�W�����v���̗������x")] float _gravitySpeed;
    [Tooltip("InputValue�̎󂯎��p")] float _movementValueX;
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
