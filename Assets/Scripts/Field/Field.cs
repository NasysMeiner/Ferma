using UnityEngine;

public class Field : MonoBehaviour, IInteractable
{
    [SerializeField] private KeyCode _keyCode;
    [SerializeField] private TypeInteraction _typeInteraction;

    public TypeInteraction TypeInteraction { get => _typeInteraction; }
    public KeyCode KeyCode { get => _keyCode; }

    public void Interact()
    {
        Debug.Log("True!");
    }
}
