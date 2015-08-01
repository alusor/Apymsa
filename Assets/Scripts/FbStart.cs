using UnityEngine;
using System.Collections;

public class FbStart : MonoBehaviour {

    void Start()
    {
        CallFBInit();
    }

    public void CallFBInit()
    {
        FB.Init(OnInitComplete, OnHideUnity);
    }

    private void OnInitComplete()
    {
        Debug.Log("FB.Init completed: Is user logged in? " + FB.IsLoggedIn);
    }

    private void OnHideUnity(bool isGameShown)
    {
        Debug.Log("Is game showing? " + isGameShown);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
