using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FBGet : MonoBehaviour {
	public Text textoui;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (FB.IsLoggedIn)
        {
            //Devuelve los datos del usuario FB
            FB.API("/me", Facebook.HttpMethod.GET, APICallback);
        }
	}
    private void APICallback(FBResult result)
    {
        
        textoui.text = result.Text;

        Debug.Log(FB.UserId);
    }
}
