using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;
using Zenject;

public class Player : MonoBehaviour
{
    public float SpeedWalk { get; set; }
    public float SpeedRun { get; set; }
    public float SpeedSteal { get; set; }
    public float SpeedRotation { get; set; }
    public Rigidbody Rigidbody { get; set; }
    public IInteractable CurrentInteractable { get; set; }
    public Transform Transform => transform;

    private PlayerMove _playerMove;
    private PlayerInput _playerInput;

    GameObject currentItem;
    int currentItemNum;
    public GameObject itemSpawner; //Потом поменяй ГО на трансформ
    public GameObject[] items;

    [Inject]
    public void InitPlayer(PlayerMove playerMove, PlayerInput playerInput)
    {
        _playerMove = playerMove;
        _playerInput = playerInput;

        _playerInput.InitPlayerInput(this);
    }

    public void LoadPar(float speedWalk, float speedRun, float speedSteal, float speedRotation)
    {
        SpeedWalk = speedWalk;
        SpeedRun = speedRun;
        SpeedSteal = speedSteal;
        SpeedRotation = speedRotation;

        Rigidbody = GetComponent<Rigidbody>();

        _playerMove.InitMove(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IInteractable interactable))
            CurrentInteractable = interactable;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable) && CurrentInteractable == interactable)
            CurrentInteractable = null;
    }

    private void FixedUpdate()
    {
        _playerMove.Move();
    }
    private void Update()
    {
        _playerMove.Rotation();
        _playerInput.ProcessInput();

        ItemsLogic();
    }

    private void ItemsLogic()
    {
        try
        {
            if (Input.GetKey("1") || Input.GetKey("2") || Input.GetKey("3") || Input.GetKey("4") || Input.GetKey("5") || Input.GetKey("6"))
                Items(Convert.ToInt32(Input.inputString));
        }
        catch (Exception e)
        {
            Debug.Log(Input.inputString);
        }
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0)
                Items(currentItemNum + 1);
            else 
                Items(currentItemNum - 1);
        }
    }
    void Items(int num)//Мешок семян, Бита, Культиватор, Ножницы, Серп, Лейка 
    {
        if (num > 6)
            num = 1;
        else if (num < 1)
            num = 6;
        currentItemNum = num;

        if (currentItem != null)
            Destroy(currentItem);

        //currentItem = Instantiate(items[num-1], itemSpawner); потом будет это, пока просто буду менять цвет вепона (не забудь поменять ГО на трансформ)

        if(itemSpawner.GetComponent<Renderer>().material.color == Color.green)
            itemSpawner.GetComponent<Renderer>().material.color = Color.red;
        else
            itemSpawner.GetComponent<Renderer>().material.color = Color.green;
    }
}
