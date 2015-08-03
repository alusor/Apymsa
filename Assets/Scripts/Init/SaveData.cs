using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveData : MonoBehaviour {
	public Text name;
	public Text mail;
	public Text mess;
	public string url;
	public GameObject reg;
	// Use this for initialization
	public void get(){
		if (name.text.Length > 0 && mail.text.Length > 0) {
			PlayerPrefs.SetString ("Name", name.text);
			PlayerPrefs.SetString ("email", mail.text);
			StartCoroutine(uploadNewUser());
		} else {
			mess.text = "Ingresa ambos datos.";
		}

	}
	IEnumerator uploadNewUser(){
		WWW connect = new WWW (url+"insertData.php?email="+mail.text+"&score="+0.ToString());
		yield return connect;
		Destroy (reg);
	}
}
