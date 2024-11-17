using UnityEngine;
using Zenject;

public class CamSenter : MonoBehaviour
{
    public Transform pl;
    public float x;
    public float y;
    public float z;

    [Inject]
    public void InitCam(Player player)
    {
        pl = player.Transform;
    }

    void FixedUpdate()
    {
        Vector3 mov = new Vector3(x, y, z);
        transform.position = pl.position + mov;
    }
}
