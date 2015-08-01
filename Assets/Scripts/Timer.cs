using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public static float Tiempo;
    Text MedidorTiempo;
	// Use this for initialization
	void Start () {
        Tiempo = 0.0f;
        MedidorTiempo = GetComponent<Text>();
        MedidorTiempo.text =  "0.00";
	}
	
	// Update is called once per frame
	void Update () {
        if (StartCarrer.startcarrer == 1 && Finish.FinishRace == 0)
        {
            Tiempo += Time.deltaTime;
            MedidorTiempo.text = Tiempo.ToString("F2");
        }
	}
}
