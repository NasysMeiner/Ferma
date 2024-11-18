using UnityEngine;

public class PlayerInput
{
    private Player _player;

    public PlayerInput(Player player)
    {
        _player = player;
    }

    public void ProcessInput()
    {
        if (_player.CurrentInteractable != null)
        {
            if (_player.CurrentInteractable.TypeInteraction == TypeInteraction.Press && Input.GetKeyDown(_player.CurrentInteractable.KeyCode))
                _player.CurrentInteractable.Interact();
            else if (_player.CurrentInteractable.TypeInteraction == TypeInteraction.Clamp && Input.GetKey(_player.CurrentInteractable.KeyCode))
                _player.CurrentInteractable.Interact();
        } 
    }
}
