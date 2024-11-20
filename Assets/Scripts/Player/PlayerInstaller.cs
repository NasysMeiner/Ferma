using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private Player _prefab;
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _speedRun;
    [SerializeField] private float _speedSteal;
    [SerializeField] private float _speedRotation;

    public override void InstallBindings()
    {
        Container.Bind<PlayerMove>().FromNew().AsSingle();
        Container.Bind<PlayerInput>().FromNew().AsSingle();

        Player player = Container.InstantiatePrefabForComponent<Player>(_prefab, _spawnPoint.transform.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();

        player.LoadPar(_speedWalk, _speedRun, _speedSteal, _speedRotation);
    }
}
