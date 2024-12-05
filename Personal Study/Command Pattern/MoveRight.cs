using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : IFCommand
{
    private PlayerController playerController;
		
    public MoveRight(PlayerController playerController)
    {
        this.playerController = playerController;
    }
		
    public void Execute()
    {
        playerController.Movement(PlayerController.Dir.RIGHT);
    }
}