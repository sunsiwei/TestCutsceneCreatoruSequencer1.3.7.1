using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UILoginReply : MonoBehaviour {

    public Text text;
    public Button button;

    public System.Action Relogin;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(OnBtnRelogin);
	}

    public void UpdateUI(LoginReplyInfo info)
    {
        switch (info.loginReplyState)
        {
            case 0:
                text.text = "success";
                button.gameObject.SetActive(false);
                break;
            case 1:
                text.text = "failed";
                break;
            case 2:
                text.text = "failed";
                break;
            default:
                break;
        }
    }

    void OnBtnRelogin()
    {
        Relogin();
    }
}
