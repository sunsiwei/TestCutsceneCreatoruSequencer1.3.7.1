using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using System.Collections.Generic;

public struct LoginReplyInfo
{
    public int loginReplyState;
    public string username;
    public string password;
}

public class LoginProxy : Proxy {

    public new const string NAME = "LoginProxy";
    public LoginProxy() : base(NAME) { }

    private Dictionary<string, string> loginVerifyInfoList;

    public override void OnRegister()
    {
        InitTestLoginVerifyInfoList();
    }
    private void InitTestLoginVerifyInfoList()
    {
        loginVerifyInfoList = new Dictionary<string, string>();
        loginVerifyInfoList.Add("xiaoming", "123");
    }

    public void LoginVerify(string name, string password)
    {
        if (loginVerifyInfoList.ContainsKey(name))
        {
            if (loginVerifyInfoList[name] == password)
            {
                LoginReplyInfo info = new LoginReplyInfo();
                info.loginReplyState = 0;
                info.username = name;
                info.password = password;
                SendNotification(NotiConst.Login_Reply, info);
            }
            else
            {
                LoginReplyInfo info = new LoginReplyInfo();
                info.loginReplyState = 1;
                SendNotification(NotiConst.Login_Reply, info);
            }
        }
        else
        {
            LoginReplyInfo info = new LoginReplyInfo();
            info.loginReplyState = 2;
            SendNotification(NotiConst.Login_Reply, info);
        }
    }
}
