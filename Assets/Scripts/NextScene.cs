using UnityEngine;
using System.Collections;

public class NextScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("CargarNivelJuego", 3.5f);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void CargarNivelJuego(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}

}
