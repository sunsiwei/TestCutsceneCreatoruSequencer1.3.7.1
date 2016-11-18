using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    public GameObject canvas;
    // Use this for initialization
    void Start()
    {
        ApplicationFacade facade = ApplicationFacade.GetInstance();
        facade.StartUp();
    }
}
