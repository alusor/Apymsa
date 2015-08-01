using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour {

    Text TextoDinero;
    int Dinero;
	// Use this for initialization
	void Start () {
        TextoDinero = GetComponent<Text>();       
	}
	
	// Update is called once per frame
	void Update () {

        Dinero = PlayerPrefs.GetInt("Money");
        TextoDinero.text = "$ " + Dinero.ToString();
	}
}
