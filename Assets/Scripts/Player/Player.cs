using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _speedRun;
    [SerializeField] private float _speedSteal;
    [SerializeField] private float _speedRotation;

    private PlayerMove _playerMove;

    public void InitPlayer(PlayerMove playerMove)
    {
        _playerMove = playerMove;

        _playerMove.InitMove(_speedWalk, _speedRun, _speedSteal, _speedRotation);
    }
}
