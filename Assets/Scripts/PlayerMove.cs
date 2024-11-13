using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public float speed;
    public float run;
    public float rot;
    public float mForce;
    private float tspeed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        tspeed = speed;
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Передвижение
        Vector3 mov = new Vector3(h, 0, v);

        if(mov.magnitude > Mathf.Abs(0.01f))
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(mov), Time.fixedDeltaTime * rot);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = run;
        }else
        {
            speed = tspeed;
        }

        rb.velocity = Vector3.ClampMagnitude(mov, 1) * speed;

        //rb.transform.Translate(Vector3.forward * Time.deltaTime * speed);

        
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftShift))
    //    {
    //        rb.AddForce(Vector3.forward * JumpForce, ForceMode.Impulse);
    //    }
    //}

}
