using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject[] boxes; // инвенрать
    int prieviusHand = 0; //запоминалка, что был ов предыдущей руке
    public GameObject seedPanel;
    public int seed = 3; // индекс семени, которе взял
    private void Awake()
    {
        instance = this;
        Player.instanse.HandNumChange += ChangeHand;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            seedPanel.SetActive(true);
        }
    }

    void ChangeHand(int num)
    {
        if (prieviusHand == num)
            return;
        if (prieviusHand != 0)
        boxes[prieviusHand - 1].GetComponent<Image>().color = Color.white;

        boxes[num - 1].GetComponent<Image>().color = Color.green;
        prieviusHand = num;
    }

    public void Buy(int num)
    {
        seed = num;
        
            switch (num)
            {
                case 0:
                    boxes[1].GetComponentInChildren<TextMeshProUGUI>().text = "Пшеница";
                    return;
                case 1:
                    boxes[1].GetComponentInChildren<TextMeshProUGUI>().text = "Огурцы";
                    return;
                case 2:
                    boxes[1].GetComponentInChildren<TextMeshProUGUI>().text = "Клубника";
                    return;
            }
    }
}
