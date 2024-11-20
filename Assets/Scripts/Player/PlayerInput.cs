using UnityEngine;
using UnityEngine.Events;

public class PlayerInput
{
    private Player _player;
    private bool _isActive = false;

    public event UnityAction<TypeInteraction, KeyCode> Interaction;

    public void InitPlayerInput(Player player)
    {
        _player = player;
    }

    public void ProcessInput()
    {
        if (_player.CurrentInteractable != null)
        {
            if ((_player.CurrentInteractable.TypeInteraction == TypeInteraction.Press || _player.CurrentInteractable.TypeInteraction == TypeInteraction.Presses) && Input.GetKeyDown(_player.CurrentInteractable.KeyCode))
                _player.CurrentInteractable.Interact();
            else if (_player.CurrentInteractable.TypeInteraction == TypeInteraction.Clamp && Input.GetKey(_player.CurrentInteractable.KeyCode))
                _player.CurrentInteractable.Interact();

            if (!_isActive)
            {
                Interaction?.Invoke(_player.CurrentInteractable.TypeInteraction, _player.CurrentInteractable.KeyCode);
                _isActive = true;
            }
        }
        else
        {
            if (_isActive)
            {
                Interaction?.Invoke(TypeInteraction.NULL, KeyCode.Numlock);
                _isActive = false;
            }
        }
    }
}
