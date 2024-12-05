using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : IFCommand
{
    private PlayerController playerController;
		
    public MoveFoward (PlayerController playerController)
    {
        this.playerController = playerController;
    }
		
    public void Execute()
    {
        playerController.Movement(PlayerController.Dir.FOWARD);
    }
}