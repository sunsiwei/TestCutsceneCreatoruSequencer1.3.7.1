using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;

public class LoginReplyMediator : Mediator {

    public new const string NAME = "LoginReplyMediator";
    public LoginReplyMediator() : base(NAME) { }

    public override System.Collections.Generic.IEnumerable<string> ListNotificationInterests
    {
        get
        {
            List<string> list = new List<string>();
            list.Add(NotiConst.Login_Reply);
            return list;
        }
    }
    public override void HandleNotification(PureMVC.Interfaces.INotification notification)
    {
        base.HandleNotification(notification);
        if (notification.Name == NotiConst.Login_Reply)
        {
            UILoginReply ui = UIManager.GetInstance().ShowUI<UILoginReply>();
            ui.Relogin = Relogin;
            
            ui.UpdateUI((LoginReplyInfo)notification.Body);
        }
    }
    void Relogin()
    { 
        UIManager.GetInstance().HideUI<UILoginReply>();
        SendNotification(NotiConst.StartUp);
    }
}
