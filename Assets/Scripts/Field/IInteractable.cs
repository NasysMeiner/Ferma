using UnityEngine;

public interface IInteractable
{
    public TypeInteraction TypeInteraction { get; }
    public KeyCode KeyCode { get; }

    public void Interact();
}

public enum TypeInteraction
{
    Press,
    Clamp,
    Presses
}