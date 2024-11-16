using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private float _speedWalk;
    private float _speedRun;
    private float _speedSteal;
    private float _speedRotation;

    private float _currentSpeed;

    public void InitMove(float speedWalk, float speedRun, float speedSteal, float speedRotation)
    {
        _speedWalk = speedWalk;
        _speedRun = speedRun;
        _speedSteal = speedSteal;
        _speedRotation = speedRotation;

        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Передвижение
        Vector3 mov = new Vector3(h, 0, v);

        if (mov.magnitude > Mathf.Abs(0.01f))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(mov), Time.fixedDeltaTime * _speedRotation);

        if (Input.GetKey(KeyCode.LeftShift))
            _currentSpeed = _speedRun;
        else if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = _speedSteal;
        else
            _currentSpeed = _speedWalk;

        rb.velocity = Vector3.ClampMagnitude(mov, 1) * _currentSpeed;
    }
}
