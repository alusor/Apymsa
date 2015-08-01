using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Finish : MonoBehaviour {

    public static int FinishRace;
    int Dinero;
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

        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        GameObject.Find("TextTime").GetComponent<Text>().text = "Tiempo: " + Timer.Tiempo.ToString("F2");
        Dinero = PlayerPrefs.GetInt("Money");
        Debug.Log(Dinero);

        if (FinishEnemy.EnemyWin == 1)
        {
            Debug.Log("Enemy Win");
            GameObject.Find("TextWin").GetComponent<Text>().text = "Perdiste";
            GameObject.Find("Star1").GetComponent<Image>().enabled = true;
            GameObject.Find("TextEarnMoney").GetComponent<Text>().text = "¡Ganaste $20!";
            PlayerPrefs.SetInt("Money", Dinero + 20); 
        }
        if (FinishEnemy.EnemyWin == 0)
        {

            Debug.Log("Player Win");
            GameObject.Find("TextWin").GetComponent<Text>().text = "¡Ganaste!";
            GameObject.Find("Star1").GetComponent<Image>().enabled = true;
            GameObject.Find("Star2").GetComponent<Image>().enabled = true;
            if (Timer.Tiempo <= 12)
            {
                GameObject.Find("Star3").GetComponent<Image>().enabled = true;
            }
            GameObject.Find("TextEarnMoney").GetComponent<Text>().text = "¡Ganaste $100!";
            PlayerPrefs.SetInt("Money", Dinero + 100);
        }
           
    }
}
