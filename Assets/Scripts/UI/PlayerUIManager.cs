using TMPro;
using UnityEngine;
using Zenject;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _textActionName;
    [SerializeField] private TMP_Text _textActionKeyCode;

    private PlayerInput _playerInput;

    private void OnDisable()
    {
        _playerInput.Interaction -= OnInteraction;
    }

    [Inject]
    public void InitUIManager(PlayerInput playerInput)
    {
        _playerInput = playerInput;

        _playerInput.Interaction += OnInteraction;
    }

    public void OnInteraction(TypeInteraction typeInteraction, KeyCode keyCode)
    {
        if(typeInteraction != TypeInteraction.NULL)
        {
            _textActionName.enabled = true;
            _textActionKeyCode.enabled = true;

            _textActionKeyCode.text = keyCode.ToString();

            if (typeInteraction == TypeInteraction.Press)
                _textActionName.text = "Нажмите";
            else if (typeInteraction == TypeInteraction.Presses)
                _textActionName.text = "Нажимайте";
            else if (typeInteraction == TypeInteraction.Clamp)
                _textActionName.text = "Зажмите";
        }
        else
        {
            _textActionName.enabled = false;
            _textActionKeyCode.enabled = false;
        }
        

    }
}
