using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : IFCommand
{
    private PlayerController playerController;
		
    public MoveLeft(PlayerController playerController)
    {
        this.playerController = playerController;
    }
		
    public void Execute()
    {
        playerController.Movement(PlayerController.Dir.LEFT);
    }
}