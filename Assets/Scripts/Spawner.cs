using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /*------------------------------------------
    //Ётот скрипт будет дл€ создани€ сетки гр€док 
    --------------------------------------------*/

    public GameObject obj;
    public int mode = 0; //»ндекс прокачки, (чек инспектор FieldGrid)
    int width, height;
    public float area;// отдалЄнность €чеек сетки друг от друга

    GameObject[] cells;

    void Awake()
    {
        switch(mode)
        {
            case 0:
                width = 3;
                height = 3;
                break;

            case 1:
                width = 4;
                height = 4;
                break;

            case 2:
                width = 5;
                height = 5;
                break;
        }

        cells = new GameObject[height * width];

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    void CreateCell(int x, int z, int i)
    {
        Vector3 position;
        position.x = x * area;
        position.y = transform.position.y;
        position.z = z * area;

        GameObject cell = cells[i] = Instantiate(obj,position, Quaternion.identity);
        cell.transform.SetParent(transform, false);
    }
}
