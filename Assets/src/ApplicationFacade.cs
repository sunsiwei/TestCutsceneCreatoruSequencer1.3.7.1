using UnityEngine;
using System.Collections;
using PureMVC.Patterns;


public class NotiConst
{
    public const string StartUp = "StartUp";
    public const string Login = "Login";
    public const string Login_Reply = "Login_Reply";
}

public class ApplicationFacade : Facade{

    protected ApplicationFacade()
    { }
    static ApplicationFacade instance;
    public static ApplicationFacade GetInstance()
    {
        if (instance == null)
        {
            instance = new ApplicationFacade();
            return instance;
        }
        else
            return instance;
    }

    public void StartUp()
    {
        SendNotification(NotiConst.StartUp);
    }

    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(NotiConst.StartUp, typeof(StartUpCommand));
        RegisterCommand(NotiConst.Login, typeof(LoginCommand));
    }
    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(new LoginProxy());
    }
    protected override void InitializeView()
    {
        base.InitializeView();

        RegisterMediator(new LoginMediator());
        RegisterMediator(new LoginReplyMediator());
    }

}
