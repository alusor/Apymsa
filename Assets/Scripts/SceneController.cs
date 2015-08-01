using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SceneController : MonoBehaviour {

    //public Image loadingScreen;
    public void changeScene(string nameScene) {
		
        if (nameScene == "Back")
        {
            Application.LoadLevel(PlayerPrefs.GetInt("LastLevel"));
            PlayerPrefs.SetInt("LastLevel", Application.loadedLevel);
        }
        else {
            PlayerPrefs.SetInt("LastLevel", Application.loadedLevel);
            Application.LoadLevel(nameScene);
        }
        
      /*  if (Application.isLoadingLevel) {
            loadingScreen.enabled = true;
        }*/
    }


    public void SetCar() { }
    public void initGame() { }
    public void carComponents() { }
    public void facebook() {
        if (FB.IsLoggedIn)
        {
            FacebookShare();
        }
        else
        {
            FB.Login("email,publish_actions");
        }
    }

    private void FacebookShare()
    {
        FB.Feed(
            link: "https://www.google.com/",
            linkName: "Tecn­o­R­a­cing",
            linkCaption: "Correo",
            linkDescription: "Mi Maxima Puntuacion",
            picture: "http://hd.wallpaperswide.com/thumbs/racing_flag-t2.jpg",
            mediaSource: "",
            actionName: "",
            actionLink: "",
            reference: "",
            properties: null
            //callback: null
            );
    }

    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "es"; 
    public void twitter() { 
        
        Application.OpenURL(TWITTER_ADDRESS +
                "?text=" + WWW.EscapeURL("Prueba TecnoRacing") +
                "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
    }
}

