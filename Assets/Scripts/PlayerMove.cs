using UnityEngine;

public class PlayerMove
{
    private Player _player;
    private Rigidbody _rb;
    private float _speedWalk;
    private float _speedRun;
    private float _speedSteal;
    private float _speedRotation;

    private float _currentSpeed;

    private float _horizontal => Input.GetAxis("Horizontal");
    private float _vertical => Input.GetAxis("Vertical");

    private Vector3 Direction => new Vector3(_horizontal, 0, _vertical);

    public void InitMove(Player player)
    {
        _player = player;

        _speedWalk = player.SpeedWalk;
        _speedRun = player.SpeedRun;
        _speedSteal = player.SpeedSteal;
        _speedRotation = player.SpeedRotation;

        _rb = player.Rigidbody;
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            _currentSpeed = _speedRun;
        else if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = _speedSteal;
        else
            _currentSpeed = _speedWalk;

        Vector3 mov = Direction;
        mov.y = _rb.velocity.y;

        _rb.velocity = Vector3.ClampMagnitude(mov, 1) * _currentSpeed;
    }

    public void Rotation()
    {
        if (Direction.magnitude > Mathf.Abs(0.01f))
            _player.Transform.rotation = Quaternion.Lerp(_player.Transform.rotation, Quaternion.LookRotation(Direction), Time.fixedDeltaTime * _speedRotation);
    }
}
