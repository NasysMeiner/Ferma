using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private int health = 3;

    public void TakeDamage(int d)
    {
        health -= d;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
