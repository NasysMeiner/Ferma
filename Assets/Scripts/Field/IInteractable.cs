using UnityEngine;

public interface IInteractable
{
    public TypeInteraction TypeInteraction { get; }
    public KeyCode KeyCode { get; }

    public void Interact();
}

public enum TypeInteraction
{
    NULL,
    Press,
    Clamp,
    Presses
}