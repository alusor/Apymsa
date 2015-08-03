using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SceneController : MonoBehaviour {

    string[] texts = new string[] 
    { 
       " Voy a correr en Tecnofuel Racing, ¡Descárgalo y corre tu también!",
       "Inicio la carrera en Tecnofuel Racing, ¡Descárgalo y mejora mis tiempos!",
       " Tecnofuel Racing está genial, ¡Descárgalo y arranca!",
       "Tecnofuel Racing, horas y hora de arrancones, te lo recomiendo"     
    };

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
    

    /*public void FacebookShare()
    { 
        string ShareMessage = texts[Random.Range(0, texts.Length)];

        /*FB.Feed(
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
    }*/


	private const string FACEBOOK_APP_ID = "559107320883310";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
	
	void FacebookShare ()
	{
		string linkParameter, nameParameter, captionParameter,descriptionParameter, pictureParameter, redirectParameter;
		linkParameter = "http://tecnofuel.com";
		nameParameter = "Tecnofuel Racing!";
		captionParameter = texts[Random.Range(0, texts.Length)];
		descriptionParameter = texts[Random.Range(0, texts.Length)];
		pictureParameter = "http://tecnofuel.com/upload/1437242399.jpg";
		redirectParameter =  "https://facebook.com";
		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
		                     "&link=" + WWW.EscapeURL(linkParameter) +
		                     "&name=" + WWW.EscapeURL(nameParameter) +
		                     "&caption=" + WWW.EscapeURL(captionParameter) + 
		                     "&description=" + WWW.EscapeURL(descriptionParameter) + 
		                     "&picture=" + WWW.EscapeURL(pictureParameter) + 
		                     "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}

    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "es"; 
    public void twitter() {

        string ShareMessage = texts[Random.Range(0, texts.Length)];
        
        Application.OpenURL(TWITTER_ADDRESS +
                "?text=" + WWW.EscapeURL(ShareMessage) +
                "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
    }
}

