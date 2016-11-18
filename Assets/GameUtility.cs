using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameUtility{

	public static Transform GetChild(Transform parent, string child)
    {
        Transform obj = parent.FindChild(child);
        return obj;
    }
    public static T GetChildComponent<T>(Transform parent, string child)where T:Component
    {
        Transform obj = parent.FindChild(child);
        return obj.GetComponent<T>();
    }
}

public class CharacterInfo
{

    public int Level { get; set; }
    public CharacterInfo()
    { }
    public CharacterInfo(int level)
    {
        Level = level;
    }
}

public class TestProxy : Proxy
{
    public new const string NAME = "TestProxy";
    public CharacterInfo Data { get; set; }

    public TestProxy()
        : base(NAME)
    {
        Data = new CharacterInfo();
    }
    public void ChangeLevel(int Change)
    {
        Data.Level = Data.Level + Change;
        SendNotification("LevelChange", Data);
    }

}

public class TestMediator : Mediator
{
    public new const string NAME = "TestMediator";

    private Button button;
    private Text text;

    public TestMediator(Transform canvas):base(NAME)
    {
        button = GameUtility.GetChildComponent<Button>(canvas, "Button");
        text = GameUtility.GetChildComponent<Text>(canvas, "Text");
        button.onClick.AddListener(OnButtonClicked);
    }
    private void OnButtonClicked()
    {
        SendNotification("LevelUp");
    }

    public override IEnumerable<string> ListNotificationInterests
    {
        get
        {
            IList<string> list = new List<string>();
            list.Add("LevelChange");
            return list;
        }
    } 

    public override void HandleNotification(PureMVC.Interfaces.INotification notification)
    {
        switch (notification.Name)
        { 
            case "LevelChange":
                CharacterInfo ci = notification.Body as CharacterInfo;
                text.text = ci.Level.ToString();
                break;
            default:
                break;
        }
    }
}

public class TestCommand : SimpleCommand
{
    public new const string NAME = "TestCommand";
    public override void Execute(PureMVC.Interfaces.INotification notification)
    {
        TestProxy proxy = (TestProxy)Facade.RetrieveProxy("TestProxy");
        proxy.ChangeLevel(1);
    }
}

public class TestFacade : Facade
{
    public TestFacade(GameObject canvas)
    {
        RegisterCommand("LevelUp", typeof(TestCommand));
        RegisterMediator(new TestMediator(canvas.transform));
        RegisterProxy(new TestProxy());
    }
}