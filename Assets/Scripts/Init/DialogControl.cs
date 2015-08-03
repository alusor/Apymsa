using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour {
	public GameObject sis;
	public GameObject reg;
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
		/*foreach (Transform child in reg.transform) {
			child.gameObject.SetActive(false);
		}*/
		reg.gameObject.SetActive (false);
		StartCoroutine (instructions());
	}
	IEnumerator instructions(){
		if (!PlayerPrefs.HasKey ("instructions")) {
			for (int i=0; i<message.Length; i++) {
				for (int j=0; j<=message[i].Length; j++) {
					box.text = message [i].Substring (0, j);
					yield return new WaitForSeconds (.02f);
				}
				yield return new WaitForSeconds (2);
			}
			PlayerPrefs.SetInt ("instructions", 0);
			reg.transform.gameObject.SetActive(true);

			/*GameObject temp =  Instantiate(reg, new Vector3(0,0,0),Quaternion.identity) as GameObject;
			temp.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
			temp.GetComponent<RectTransform>().offsetMin = sis.GetComponent<RectTransform>().offsetMin;
			temp.GetComponent<RectTransform>().offsetMax = sis.GetComponent<RectTransform>().offsetMax;
			SaveData t1 =  gameObject.GetComponent<SaveData>();
			t1.name = GameObject.Find("Apodo").GetComponent<Text>();
			Button agree = GameObject.FindGameObjectWithTag("button").GetComponent<Button>();
			Debug.Log(agree.name); 
			agree.onClick.AddListener(() => {t1.get();});
			t1.reg = temp;*/

			//temp.GetComponentInChildren<Button>().onClick.AddListener(()=>{FindObjectOfType<SaveData>().get();});
			//temp.GetComponent<RectTransform>().offsetMin  = new Vector2(0,0);
			//temp.GetComponent<RectTransform>().offsetMin =  new Vector2(0,0);
		} else
			Destroy (reg);

		Destroy (sis);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
