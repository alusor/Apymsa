using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buy : MonoBehaviour {

    private string ObjetoAComprar;
    private int Costo;
    private int Dinero;

    private Text Texto;
    private Image Marco;
    private Image Blur;
    private Image Button1;
    private Image Button2;
    public Text t1;
    public Text t2;

    public AudioClip MoneyClip;

	// Use this for initialization
	void Start () {
        //Prueba Dinero
        PlayerPrefs.SetInt("Money", 1000);

        Texto = GameObject.Find("TextMensaje").GetComponent<Text>();
        Marco = GameObject.Find("HolderMensaje").GetComponent<Image>();
        Blur = GameObject.Find("HolderBlur").GetComponent<Image>();
        Button1 = GameObject.Find("Button1Mensaje").GetComponent<Image>();
        Button2 = GameObject.Find("Button2Mensaje").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShopMessage(string objeto)
    {
        ObjetoAComprar = objeto;
        if (ObjetoAComprar == "Bobina")
        {
            Costo = 100;
        }
        if (ObjetoAComprar == "Bomba")
        {
            Costo = 360;
        }
        if (ObjetoAComprar == "Cables")
        {
            Costo = 120;
        }
        if (ObjetoAComprar == "Inyector")
        {
            Costo = 650;
        }
        if (ObjetoAComprar == "Turbo") {
            Costo = 50;
        }
        Texto.text = "¿Comprar " + objeto + " por " +Costo.ToString()+" ?";
        Blur.enabled = true;
        Texto.enabled = true;
        Marco.enabled = true;
        Button1.enabled = true;
        Button2.enabled = true;
        t1.enabled = true;
        t2.enabled = true;
        
    }

    public void NoMessage() {

        Blur.enabled = false;
        Texto.enabled = false;
        Marco.enabled = false;
        Button1.enabled = false;
        Button2.enabled = false;
        t1.enabled = false;
        t2.enabled = false;
    }

    public void BuyButton() {

        Dinero = PlayerPrefs.GetInt("Money");
        if (Dinero > Costo - 1)
        {
            string AutoActual = PlayerPrefs.GetString("SelectionCar");

            //Autos Disponibles
            //"Dodge"
            //"Jetta":
            //"Honda":
            //"Nissan":
            //"Camaro":
            //"Mustang":
            Upgrade(AutoActual);
        }
        else
        {
            Debug.Log("Ahorita No Joven");
            Texto.text = "No tienes Suficiente Dinero";
            Button1.enabled = false;
            t2.enabled = false;
        }
    }

    private void Upgrade(string AutoActual)
    {
        //Bobina aunmenta MaxSpeed
        //Bomba aunmenta Aceleration
        //Cables aunmentan MaxSpeed
        //Inyector aunmenta Aceleration
        //Turbo aunmenta

        if (ObjetoAComprar == "Bobina")
        {
            Debug.Log(PlayerPrefs.GetInt(AutoActual + "Bobina"));
            if (PlayerPrefs.HasKey(AutoActual + "Bobina") && !(PlayerPrefs.GetInt(AutoActual + "Bobina") >= 3))
            {
                PlayerPrefs.SetInt(AutoActual + "Bobina", PlayerPrefs.GetInt(AutoActual + "Bobina") + 1);
                Debug.Log(PlayerPrefs.GetInt(AutoActual + "Bobina"));
                NoMessage();
                Debug.Log("Comprado");
                PlayerPrefs.SetInt("Money", Dinero - Costo);
                GetComponent<AudioSource>().PlayOneShot(MoneyClip);
            }
            else if (!PlayerPrefs.HasKey(AutoActual + "Bobina"))
            {
                PlayerPrefs.SetInt(AutoActual + "Bobina", 1);
                Debug.Log(PlayerPrefs.GetInt(AutoActual + "Bobina"));
                NoMessage();
                Debug.Log("Comprado");
                PlayerPrefs.SetInt("Money", Dinero - Costo);
                GetComponent<AudioSource>().PlayOneShot(MoneyClip);
            }
            else if (PlayerPrefs.GetInt(AutoActual + "Bobina") >= 3)
            {
                Debug.Log("Solo podeis comprar 3 :v");
                Texto.text = "Solo puedes comprar 3 " + ObjetoAComprar + "s para " + AutoActual;
                Button1.enabled = false;
                t2.enabled = false;
            }
        }

        if (ObjetoAComprar == "Bomba")
        {
            if (PlayerPrefs.HasKey(AutoActual + "Bomba") && !(PlayerPrefs.GetInt(AutoActual + "Bomba") >= 3))
            {
                PlayerPrefs.SetInt(AutoActual + "Bomba", PlayerPrefs.GetInt(AutoActual + "Bomba") + 1);
                Debug.Log(PlayerPrefs.GetInt(AutoActual + "Bomba"));
                NoMessage();
                Debug.Log("Comprado");
                PlayerPrefs.SetInt("Money", Dinero - Costo);
                GetComponent<AudioSource>().PlayOneShot(MoneyClip);
            }
            else if (!PlayerPrefs.HasKey(AutoActual + "Bomba"))
            {
                PlayerPrefs.SetInt(AutoActual + "Bomba", 1);
                Debug.Log(PlayerPrefs.GetInt(AutoActual + "Bomba"));
                NoMessage();
                Debug.Log("Comprado");
                PlayerPrefs.SetInt("Money", Dinero - Costo);
                GetComponent<AudioSource>().PlayOneShot(MoneyClip);
            }
            else if (PlayerPrefs.GetInt(AutoActual + "Bomba") >= 3)
            {
                Debug.Log("Solo podeis comprar 3 :v");
                Texto.text = "Solo puedes comprar 3 " + ObjetoAComprar + "s para " + AutoActual;
                Button1.enabled = false;
                t2.enabled = false;
            }
        }

        if (ObjetoAComprar == "Cables")
        {
            if (PlayerPrefs.HasKey(AutoActual + "Cables") && !(PlayerPrefs.GetInt(AutoActual + "Cables") >= 3))
            {
                PlayerPrefs.SetInt(AutoActual + "Cables", PlayerPrefs.GetInt(AutoActual + "Cables") + 1);
                Debug.Log(PlayerPrefs.GetInt(AutoActual + "Cables"));
                NoMessage();
                Debug.Log("Comprado");
                PlayerPrefs.SetInt("Money", Dinero - Costo);
                GetComponent<AudioSource>().PlayOneShot(MoneyClip);
            }
            else if (!PlayerPrefs.HasKey(AutoActual + "Cables"))
            {
                PlayerPrefs.SetInt(AutoActual + "Cables", 1);
                Debug.Log(PlayerPrefs.GetInt(AutoActual + "Cables"));
                NoMessage();
                Debug.Log("Comprado");
                PlayerPrefs.SetInt("Money", Dinero - Costo);
                GetComponent<AudioSource>().PlayOneShot(MoneyClip);
            }
            else if (PlayerPrefs.GetInt(AutoActual + "Cables") >= 3)
            {
                Debug.Log("Solo podeis comprar 3 :v");
                Texto.text = "Solo puedes comprar 3 " + ObjetoAComprar + " para " + AutoActual;
                Button1.enabled = false;
                t2.enabled = false;
            }
        }

        if (ObjetoAComprar == "Inyector")
        {
            if (PlayerPrefs.HasKey(AutoActual + "Inyector") && !(PlayerPrefs.GetInt(AutoActual + "Inyector") >= 3))
            {
                PlayerPrefs.SetInt(AutoActual + "Inyector", PlayerPrefs.GetInt(AutoActual + "Inyector") + 1);
                Debug.Log(PlayerPrefs.GetInt(AutoActual + "Inyector"));
                NoMessage();
                Debug.Log("Comprado");
                PlayerPrefs.SetInt("Money", Dinero - Costo);
                GetComponent<AudioSource>().PlayOneShot(MoneyClip);
            }
            else if (!PlayerPrefs.HasKey(AutoActual + "Inyector"))
            {
                PlayerPrefs.SetInt(AutoActual + "Inyector", 1);
                Debug.Log(PlayerPrefs.GetInt(AutoActual + "Inyector"));
                NoMessage();
                Debug.Log("Comprado");
                PlayerPrefs.SetInt("Money", Dinero - Costo);
                GetComponent<AudioSource>().PlayOneShot(MoneyClip);
            }
            else if (PlayerPrefs.GetInt(AutoActual + "Inyector") >= 3)
            {
                Debug.Log("Solo podeis comprar 3 :v");
                Texto.text = "Solo puedes comprar 3 " + ObjetoAComprar + "es para " + AutoActual;
                Button1.enabled = false;
                t2.enabled = false;
            }
        }

        if (ObjetoAComprar == "Turbo")
        {
            if (PlayerPrefs.HasKey(AutoActual + "Turbo") && !(PlayerPrefs.GetInt(AutoActual + "Turbo") >= 3))
            {
                PlayerPrefs.SetInt(AutoActual + "Turbo", PlayerPrefs.GetInt(AutoActual + "Turbo") + 1);
                Debug.Log(PlayerPrefs.GetInt(AutoActual + "Turbo"));
                NoMessage();
                Debug.Log("Comprado");
                PlayerPrefs.SetInt("Money", Dinero - Costo);
                GetComponent<AudioSource>().PlayOneShot(MoneyClip);
            }
            else if (!PlayerPrefs.HasKey(AutoActual + "Turbo"))
            {
                PlayerPrefs.SetInt(AutoActual + "Turbo", 1);
                Debug.Log(PlayerPrefs.GetInt(AutoActual + "Turbo"));
                NoMessage();
                Debug.Log("Comprado");
                PlayerPrefs.SetInt("Money", Dinero - Costo);
                GetComponent<AudioSource>().PlayOneShot(MoneyClip);
            }
            else if (PlayerPrefs.GetInt(AutoActual + "Turbo") >= 3)
            {
                Debug.Log("Solo podeis comprar 3 :v");
                Texto.text = "Solo puedes comprar 3 " + ObjetoAComprar + "s para " + AutoActual;
                Button1.enabled = false;
                t2.enabled = false;
            }
        }
    }
}
