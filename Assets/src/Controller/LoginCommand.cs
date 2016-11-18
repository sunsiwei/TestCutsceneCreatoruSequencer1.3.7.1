using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

public class LoginCommand : SimpleCommand {

    public override void Execute(PureMVC.Interfaces.INotification notification)
    {
        LoginMediator.LoginInfo loginInfo = (LoginMediator.LoginInfo)notification.Body;
        LoginProxy loginProxy = ApplicationFacade.GetInstance().RetrieveProxy(LoginProxy.NAME) as LoginProxy;
        loginProxy.LoginVerify(loginInfo.username, loginInfo.password);
        
    }
}
