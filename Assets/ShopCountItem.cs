using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopCountItem : MonoBehaviour {

    private Text Text;
    private string Name;
	// Use this for initialization
	void Start () {
        Text = gameObject.GetComponent<Text>();
        Name = gameObject.name.ToString();

        string AutoActual = PlayerPrefs.GetString("SelectionCar");

        if (Name == "TextBobina") 
        {
            if (PlayerPrefs.HasKey(AutoActual + "Bobina"))
            {
                Text.text = "x" + PlayerPrefs.GetInt(AutoActual + "Bobina").ToString();
            }
        }
        if (Name == "TextBomba")
        {
            if (PlayerPrefs.HasKey(AutoActual + "Bomba"))
            {
                Text.text = "x" + PlayerPrefs.GetInt(AutoActual + "Bomba").ToString();
            }
        }
        if (Name == "TextCables")
        {
            if (PlayerPrefs.HasKey(AutoActual + "Cables"))
            {
                Text.text = "x" + PlayerPrefs.GetInt(AutoActual + "Cables").ToString();
            }
        }
        if (Name == "TextInyector")
        {
            if (PlayerPrefs.HasKey(AutoActual + "Inyector"))
            {
                Text.text = "x" + PlayerPrefs.GetInt(AutoActual + "Inyector").ToString();
            }
        }
        if (Name == "TextTurbo")
        {
            if (PlayerPrefs.HasKey(AutoActual + "Turbo"))
            {
                Text.text = "x" + PlayerPrefs.GetInt(AutoActual + "Turbo").ToString();
            }
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        Text = gameObject.GetComponent<Text>();
        Name = gameObject.name.ToString();

        string AutoActual = PlayerPrefs.GetString("SelectionCar");

        if (Name == "TextBobina")
        {
            if (PlayerPrefs.HasKey(AutoActual + "Bobina"))
            {
                Text.text = "x" + PlayerPrefs.GetInt(AutoActual + "Bobina").ToString();
            }
        }
        if (Name == "TextBomba")
        {
            if (PlayerPrefs.HasKey(AutoActual + "Bomba"))
            {
                Text.text = "x" + PlayerPrefs.GetInt(AutoActual + "Bomba").ToString();
            }
        }
        if (Name == "TextCables")
        {
            if (PlayerPrefs.HasKey(AutoActual + "Cables"))
            {
                Text.text = "x" + PlayerPrefs.GetInt(AutoActual + "Cables").ToString();
            }
        }
        if (Name == "TextInyector")
        {
            if (PlayerPrefs.HasKey(AutoActual + "Inyector"))
            {
                Text.text = "x" + PlayerPrefs.GetInt(AutoActual + "Inyector").ToString();
            }
        }
        if (Name == "TextTurbo")
        {
            if (PlayerPrefs.HasKey(AutoActual + "Turbo"))
            {
                Text.text = "x" + PlayerPrefs.GetInt(AutoActual + "Turbo").ToString();
            }
        }
	}
}
