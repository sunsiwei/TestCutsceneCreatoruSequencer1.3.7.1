using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;

public class LoginMediator : Mediator {
    public new const string NAME = "LoginMediator";
    public LoginMediator() : base(NAME) { }

    public struct LoginInfo
    {
        public string username;
        public string password;
    }

    UILogin ui;

    public override System.Collections.Generic.IEnumerable<string> ListNotificationInterests
    {
        get
        {
            List<string> list = new List<string>();
            list.Add(NotiConst.StartUp);
            list.Add(NotiConst.Login_Reply);
            return list;
        }
    }
    public override void HandleNotification(PureMVC.Interfaces.INotification notification)
    {
        base.HandleNotification(notification);
            
        switch (notification.Name)
        {
            case NotiConst.StartUp:
                ui = UIManager.GetInstance().ShowUI<UILogin>();
                ui.Login = Login;
                break;
            case NotiConst.Login_Reply:
                UIManager.GetInstance().HideUI<UILogin>();
                break;
            default:
                break;
        }
    }

    public void Login(string username, string password)
    {
        Debug.Log("LoginMediator Login");
        LoginInfo info = new LoginInfo();
        info.username = username;
        info.password = password;
        SendNotification(NotiConst.Login, info);
    }
}
