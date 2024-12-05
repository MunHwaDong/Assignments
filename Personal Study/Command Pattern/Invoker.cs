using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//기본적인 Invoker
public class Invoker : MonoBehaviour
{
    private IFCommand command;
		
    public void ExecuteCommand(IFCommand command)
    {
        command.Execute();
    }
}
