using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Finish : MonoBehaviour {

    public static int FinishRace;
    int Dinero;
	float score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D other) {

        FinishRace = 1;
        GameObject.Find("Blur").GetComponent<Image>().enabled = true;
        GameObject.Find("FinishBox").GetComponent<Image>().enabled = true;
        GameObject.Find("TextWin").GetComponent<Text>().enabled = true;
        GameObject.Find("TextTime").GetComponent<Text>().enabled = true;
        GameObject.Find("backfinish").GetComponent<Image>().enabled = true;
        GameObject.Find("TextEarnMoney").GetComponent<Text>().enabled = true;
        GameObject.Find("fb").GetComponent<Image>().enabled = true;
        GameObject.Find("tw").GetComponent<Image>().enabled = true;

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
		string tim = Timer.Tiempo.ToString ("F2");
		float ti = Timer.Tiempo;
        GameObject.Find("TextTime").GetComponent<Text>().text = "Tiempo: " + tim;
        Dinero = PlayerPrefs.GetInt("Money");
        Debug.Log(Dinero);

        if (FinishEnemy.EnemyWin == 1)
		{	int wi = (20 * (70-(int)ti))/10;
            Debug.Log("Enemy Win");
            GameObject.Find("TextWin").GetComponent<Text>().text = "Perdiste";
            GameObject.Find("Star1").GetComponent<Image>().enabled = true;
            GameObject.Find("TextEarnMoney").GetComponent<Text>().text = "¡Obtuviste $"+wi.ToString()+"!";
            PlayerPrefs.SetInt("Money", Dinero+wi); 
			score = (20 * (100-ti));
        }
        if (FinishEnemy.EnemyWin == 0)
        {
			int wi = (100 * (70-(int)ti))/10;
            Debug.Log("Player Win");
            GameObject.Find("TextWin").GetComponent<Text>().text = "¡Ganaste!";
            GameObject.Find("Star1").GetComponent<Image>().enabled = true;
            GameObject.Find("Star2").GetComponent<Image>().enabled = true;
            if (Timer.Tiempo <= 12)
            {
                GameObject.Find("Star3").GetComponent<Image>().enabled = true;
            }
            GameObject.Find("TextEarnMoney").GetComponent<Text>().text = "¡Obtuviste $"+wi+"!";
            PlayerPrefs.SetInt("Money", Dinero + wi);
			score = (100 * (100-ti));

        }
		Debug.Log (score);
           
    }

    private string fbshare() {

        string[] textswin = new string[] 
        { 
           "Alcancé un tiempo de " + Timer.Tiempo + ", descarga Tecnofuel Racing y mejóralo",
           "Mi tiempo en carrera fue de " + Timer.Tiempo + ", ¿puedes mejorarlo? Descarga Tecnofuel Racing"
        };
            string[] textslose = new string[] 
        { 
           "Uh! No alcancé al contrario, ¿lo puedes vencer? Prueba Tecnofuel Racing",
           "Por un pelo lo logro! Aún así es muy divertido, prueba Tecnofuel Racing"     
        };

        if (FinishEnemy.EnemyWin == 1)
        {
           return  textslose[Random.Range(0, textslose.Length)];
        }
        if (FinishEnemy.EnemyWin == 0)
        {
            return textswin[Random.Range(0, textswin.Length)];
        }
		return "";
    }
	private const string FACEBOOK_APP_ID = "559107320883310";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
	
	public void FacebookShare ()
	{
		string linkParameter, nameParameter, captionParameter,descriptionParameter, pictureParameter, redirectParameter;
		linkParameter = "http://tecnofuel.com";
		nameParameter = "Tecnofuel Racing!";
		captionParameter = fbshare();
		descriptionParameter = fbshare();
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
    public void twshare() {

        string[] textswin = new string[] 
        { 
           "Alcancé un tiempo de " + Timer.Tiempo + ", descarga Tecnofuel Racing y mejóralo",
           "Mi tiempo en carrera fue de " + Timer.Tiempo + ", ¿puedes mejorarlo? Descarga Tecnofuel Racing"
        };
        string[] textslose = new string[] 
        { 
           "Uh! No alcancé al contrario, ¿lo puedes vencer? Prueba Tecnofuel Racing",
           "Por un pelo lo logro! Aún así es muy divertido, prueba Tecnofuel Racing"     
        };

        if (FinishEnemy.EnemyWin == 1)
        {
            string ShareMessage = textslose[Random.Range(0, textslose.Length)];
            Application.OpenURL(TWITTER_ADDRESS +
                "?text=" + WWW.EscapeURL(ShareMessage) +
                "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
        }
        if (FinishEnemy.EnemyWin == 0)
        {
            string ShareMessage = textswin[Random.Range(0, textswin.Length)];
            Application.OpenURL(TWITTER_ADDRESS +
                "?text=" + WWW.EscapeURL(ShareMessage) +
                "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
        }
    }
}
