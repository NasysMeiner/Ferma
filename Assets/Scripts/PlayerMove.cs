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
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Передвижение
        Vector3 mov = new Vector3(h, 0, v);

        if (mov.magnitude > Mathf.Abs(0.01f))
            _player.Transform.rotation = Quaternion.Lerp(_player.Transform.rotation, Quaternion.LookRotation(mov), Time.fixedDeltaTime * _speedRotation);

        if (Input.GetKey(KeyCode.LeftShift))
            _currentSpeed = _speedRun;
        else if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = _speedSteal;
        else
            _currentSpeed = _speedWalk;

        _rb.velocity = Vector3.ClampMagnitude(mov, 1) * _currentSpeed;
    }
}
