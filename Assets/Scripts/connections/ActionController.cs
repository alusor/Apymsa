using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionController : MonoBehaviour {
    public InputField mail;
    public InputField score;
	// Use this for initialization
    public void newUser() {

        if (PlayerPrefs.GetString("email")=="null")
        {
            registerData data = GetComponent<registerData>();
            data.uploadData(mail.text, int.Parse(score.text));
            PlayerPrefs.SetString("email", mail.text);
        }
        else {
            UpdateData data = GetComponent<UpdateData>();
            data.uploadData(mail.text, int.Parse(score.text));
        }
    }
}
