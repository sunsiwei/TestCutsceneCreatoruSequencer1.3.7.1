using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UILogin : MonoBehaviour {

    public System.Action<string, string> Login;

    public InputField username;
    public InputField password;
    public Button button;
	// Use this for initialization
	void Start () {
        username.onValueChange.AddListener(OnUsernameEndEdit);

        button.onClick.AddListener(OnButtonClicked);
	}

    void OnUsernameEndEdit(string a)
    {
        Debug.Log("onValueChange: " + a);
    }

    void OnButtonClicked()
    {
        Debug.Log("OnButtonClicked");
        Login(username.text, password.text);
    }

}
