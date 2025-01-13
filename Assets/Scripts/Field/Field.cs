using UnityEngine;

public class Field : MonoBehaviour, IInteractable
{
    [SerializeField] private KeyCode _keyCode;
    [SerializeField] private TypeInteraction _typeInteraction;

    public TypeInteraction TypeInteraction { get => _typeInteraction; }
    public KeyCode KeyCode { get => _keyCode; }

    int state = 2; //состояние поля 0 - ничего, 1 - засеяно, 2 - надо полить и т.д.

    bool isSeed = false; // засеяно ли поле?

    public void Interact()
    {
        if (state == Player.instanse.currentItemNum)
        {
            switch (state)
            {
                case 2:
                    Seed();
                    break;
            }
        }
        else
        {
            Debug.Log(Player.instanse.currentItemNum);
            Debug.Log(state);
        }
    }

    void Seed()
    {
        if (isSeed == false)
        {
            switch (UIManager.instance.seed) 
            {
                case 0:
                    GetComponent<Renderer>().material.color = Color.black;
                    isSeed = true;
                    break;
                case 1:
                    GetComponent<Renderer>().material.color = Color.green;
                    isSeed = true;
                    break;
                case 2:
                    GetComponent<Renderer>().material.color = Color.red;
                    isSeed = true;
                    break;
                case 3:
                    Debug.Log("Choose seed");
                    break;
            }
        }
        else
            Debug.Log("Seeded");
    }
}
