using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

public class StartUpCommand : SimpleCommand {

    public override void Execute(PureMVC.Interfaces.INotification notification)
    {
        Debug.Log("StartUpCommand");
    }
}
