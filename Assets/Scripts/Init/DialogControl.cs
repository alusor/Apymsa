using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour {
	string[] message = new string[]{
		"Bienvenido a Tecnofuel Racing a continuación te explicare algunas cosas importantes para que puedas jugar.",
		"Si quieres ponerte a correr dirígete a carrera, o si quieres puedes ir al garage, antes de empezar una carrera recuerda que tienes que pisar el acelerador!",
		"Cuando lo necesites podrás ir a la tienda a comprar mejoras para tu auto, cada compra se asignara automáticamente al ultimo auto que usaste. ",
		"También podrás ver que tan buen piloto eres, dirigete a perfil y podras ver todo tu historial verdad que es interesante? ",
		"Por ultimo necesitamos que te pongas un apodo e ingreses tu correo, para que tu puntaje compita contra el resto del mundo!"
	};
	public Text box;
	// Use this for initialization
	void Start () {
		StartCoroutine (instructions());
	}
	IEnumerator instructions(){
		for(int i=0;i<message.Length;i++){
			for(int j=0;j<=message[i].Length;j++){
				box.text = message[i].Substring(0,j);
				yield return new WaitForSeconds (.05f);
			}
			yield return new WaitForSeconds (2);
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
