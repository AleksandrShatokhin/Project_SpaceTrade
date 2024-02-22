using UnityEngine;

public class PlayerController : MonoBehaviour, IInitialize
{
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;

    private float _defaultHorizontalSpeed;
    private float _defaultVerticalSpeed;

    private float _horizontalInput;
    private float _verticalInput;

    private Rigidbody2D _rigidbody;
    private bool _isFacingRight;

    public void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isFacingRight = true;

    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        SetDirection();
    }

    private void FixedUpdate()
    {
        Vector2 movementVector = new Vector2(_horizontalInput, _verticalInput).normalized;
        Vector3 moveVector3 = new Vector3(movementVector.x * GetSpeedParse(_horizontalSpeed), movementVector.y * GetSpeedParse(_verticalSpeed), 0.0f);
        _rigidbody.MovePosition(transform.position + moveVector3);
    }

    private float GetSpeedParse(float speed) => speed = speed * 0.1f;

    private void SetDirection()
    {
        if (_isFacingRight == false && _horizontalInput > 0)
        {
            SwitchDirection();
        }

        if (_isFacingRight == true && _horizontalInput < 0)
        {
            SwitchDirection();
        }
    }

    private void SwitchDirection()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x = scaler.x * -1;
        transform.localScale = scaler;
    }
}