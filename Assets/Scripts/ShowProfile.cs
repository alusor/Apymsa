using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowProfile : MonoBehaviour {
    public Text[] lista;
	// Use this for initialization
	void Start () {
        lista[0].text = "Nick: " + PlayerPrefs.GetString("Name");
        lista[1].text = "Email: "+PlayerPrefs.GetString("email");
        lista[2].text = "Max. Puntación: "+PlayerPrefs.GetFloat("maxScore").ToString();
        lista[3].text = "Dinero: "+PlayerPrefs.GetInt("Money").ToString();
        lista[4].text = "Carreras jugadas: "+PlayerPrefs.GetInt("racesPlayed").ToString();
        lista[5].text = "Carreras ganadas: "+PlayerPrefs.GetInt("racesWin").ToString();
        //lista[6].text = PlayerPrefs.GetInt("racesLose").ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
