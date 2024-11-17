using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    public float SpeedWalk { get; set; }
    public float SpeedRun { get; set; }
    public float SpeedSteal { get; set; }
    public float SpeedRotation { get; set; }
    public Rigidbody Rigidbody { get; set; }
    public Transform Transform => transform;

    private PlayerMove _playerMove;

    [Inject]
    public void InitPlayer(PlayerMove playerMove)
    {
        _playerMove = playerMove;
    }

    public void LoadPar(float speedWalk, float speedRun, float speedSteal, float speedRotation)
    {
        SpeedWalk = speedWalk;
        SpeedRun = speedRun;
        SpeedSteal = speedSteal;
        SpeedRotation = speedRotation;

        Rigidbody = GetComponent<Rigidbody>();

        _playerMove.InitMove(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void FixedUpdate()
    {
        _playerMove.Move();
    }
    private void Update()
    {
        _playerMove.Rotation();
    }
}
