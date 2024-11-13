using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSenter : MonoBehaviour
{
    public Transform pl;
    public float x;
    public float y;
    public float z;

    void FixedUpdate()
    {
        Vector3 mov = new Vector3(x, y, z);
        transform.position = pl.position + mov;
    }
}
