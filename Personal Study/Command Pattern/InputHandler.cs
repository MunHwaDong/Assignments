using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Client
public class InputHandler : MonoBehaviour
{
    //Invoker
    private Invoker invoker;
		
    //Receiver
    private PlayerController playerController;
		
    //Command
    private IFCommand AKeyCommand, DKeyCommand, WKeyCommand;
		
    void Start()
    {
        invoker = gameObject.AddComponent<Invoker>();
        playerController = FindObjectOfType<PlayerController>();
				
        AKeyCommand = new MoveLeft(playerController);
        DKeyCommand = new MoveRight(playerController);
        WKeyCommand = new MoveFoward(playerController);
    }
		
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            invoker.ExecuteCommand(AKeyCommand);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            invoker.ExecuteCommand(DKeyCommand);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            invoker.ExecuteCommand(WKeyCommand);
        }
    }
}
