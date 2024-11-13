using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class EnemyMove : MonoBehaviour
{
    public Transform obj;
    public float speed;

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 mov = new Vector3(0, 0, 1);

        transform.LookAt(obj.position);

        transform.Translate(mov * speed * Time.fixedDeltaTime);
    }
}