using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuSelectionCar : MonoBehaviour {
    public GameObject[] carList;
    public string carSelected;
    private int carSelectionIndex = 0;
    public GameObject instancePlace;
    private GameObject actualCar;
    private Color opacity;
    public Text text;
    public Button locked;
    private int costo;
    private int money;

    //status box
    public Slider power;
    public Slider height;
    public Slider grip;
    private int unlocked;
    private SimpleControlVehicle getStats;

    //Animator 
    public Animator buy;
    public Text buytext;

    void Awake() {
        StartCarrer.startcarrer = 0;
        Finish.FinishRace = 0;
        if (PlayerPrefs.HasKey("SelectionCar")) {
            switch (PlayerPrefs.GetString("SelectionCar"))
            {
                case "Dodge":
                    carSelectionIndex = 5;
                    break;
                case "Jetta":
                    carSelectionIndex = 0;
                    break;
                case "Honda":
                    carSelectionIndex = 2;
                    break;
                case "Nissan":
                    carSelectionIndex = 1;
                    break;
                case "Camaro":
                    carSelectionIndex = 4;
                    break;
                case "Mustang":
                    carSelectionIndex = 3;
                    break;
                default:
                    break;
            }
        } 
    }
   
    void Start() {
        actualCar = Instantiate(carList[carSelectionIndex], instancePlace.transform.position, Quaternion.identity) as GameObject;
        getStats = actualCar.GetComponent<SimpleControlVehicle>();
        power.value = getStats.gears[1].GearMaxSpeed / 17;
        height.value = getStats.gears[1].GearAcceleration * 1.5f;
        grip.value = getStats.backForce / 20f;
        updaData();
        money = PlayerPrefs.GetInt("Money");
       // text.text += "\n Max: " + actualCar.GetComponent<SimpleControlVehicle>().maxSpeed;
        opacity = new Color(0, 0, 0, 50);
    }
    public void carSelection(int index)
    {

        if (index > 0 && carSelectionIndex < 5)
        {   
            carSelectionIndex += 1;
            Destroy(actualCar);

            //  carSelectionIndex += index;
            actualCar = Instantiate(carList[carSelectionIndex], instancePlace.transform.position, Quaternion.identity) as GameObject;
            getStats = actualCar.GetComponent<SimpleControlVehicle>();
            power.value = getStats.gears[1].GearMaxSpeed / 17;
            height.value = getStats.gears[1].GearAcceleration* 1.5f;
            grip.value = getStats.backForce / 20f;
        }
        if (index < 0 && carSelectionIndex > 0)
        {
            carSelectionIndex -= 1;
            Destroy(actualCar);
            //  carSelectionIndex += index;
            actualCar = Instantiate(carList[carSelectionIndex], instancePlace.transform.position, Quaternion.identity) as GameObject;
            getStats = actualCar.GetComponent<SimpleControlVehicle>();
            power.value = getStats.gears[1].GearMaxSpeed / 17;
            height.value = getStats.gears[1].GearAcceleration * 1.5f;
            grip.value = getStats.backForce / 20f;
        }
        Debug.Log(carSelectionIndex);
        //text.text = actualCar.name.Split('(')[0] + "\n Max: " + actualCar.GetComponent<SimpleControlVehicle>().maxSpeed * 1.15;
        updaData();
        
        
            
            

    }
    public void radyToRace() {
        PlayerPrefs.SetInt("LastLevel", Application.loadedLevel);
        if (unlocked == 1)
        {
            string[] name = actualCar.name.Split('(');
            //Debug.Log(name[0]);
            carSelected = name[0];
            
            Application.LoadLevel("SelectStageScene");

        }
        else {
            Debug.Log("Necesitas comprar el auto primero.");
        }
        
    }
    public void updateStatus(string nameCar) { 
        
    }
    public void selectCar()
    {
        PlayerPrefs.SetString("SelectionCar", carSelected);

        SceneController escena = new SceneController();
        escena.changeScene("cityScene"); //Pruebas Obsoleto
    }
    public void updaData(){
        text.text = actualCar.name.Split('(')[0];
        buy.SetBool("enter",false);
        switch (text.text)
        {
            case "Dodge":
                text.text = "CHALLENGER";
                unlocked = PlayerPrefs.GetInt("HasDodge");
                costo = 58500;
                break;
            case "Jetta":
                text.text = "VW JETTA";
                unlocked = PlayerPrefs.GetInt("HasJetta");
                break;
            case "Honda":
                text.text = "S2000";
                unlocked = PlayerPrefs.GetInt("HasHonda");
                costo = 25800;
                break;
            case "Nissan":
                text.text = "240SX";
                unlocked = PlayerPrefs.GetInt("HasNissan");
                costo = 13900;
                break;
            case "Camaro":
                text.text = "CAMARO";
                unlocked = PlayerPrefs.GetInt("HasCamaro");
                costo = 38600;
                break;
            case "Mustang":
                text.text = "MUSTAG";
                unlocked = PlayerPrefs.GetInt("HasMustang");
                costo = 45300;
                break;
            default:
                break;
        }
        if (unlocked == 1)
        {
            locked.GetComponent<Image>().enabled = false;
            locked.enabled = false;
            string[] name = actualCar.name.Split('(');
            //Debug.Log(name[0]);
            carSelected = name[0];
            PlayerPrefs.SetString("SelectionCar", carSelected);
        }
        else {
            locked.GetComponent<Image>().enabled = true;
            locked.enabled = true;
        }
        
        updateStatus(actualCar.name.Split('(')[0]);
        Debug.Log("desbloqueado: " + unlocked.ToString());
    }
    public void actionBuy(int a) {
        if (a == 1) {
            buy.SetBool("enter",true);
            buytext.text = "El " + text.text + " cuesta: "+costo+"\nDeseas comprarlo?";
        }
        if(a==0){
            buy.SetBool("enter",false);
        }
        if (a == 2) {
            string test = actualCar.name.Split('(')[0];
            switch (test)
            {
                case "Dodge":
                    PlayerPrefs.SetInt("HasDodge",1);
                    unlocked = PlayerPrefs.GetInt("HasDodge");
                    break;
                case "Jetta":
                    PlayerPrefs.SetInt("HasJetta", 1);
                    unlocked = PlayerPrefs.GetInt("HasJetta");
                    break;
                case "Honda":
                    PlayerPrefs.SetInt("HasHonda", 1);
                    unlocked = PlayerPrefs.GetInt("HasHonda");
                    break;
                case "Nissan":
                    PlayerPrefs.SetInt("HasNissan", 1);
                    unlocked = PlayerPrefs.GetInt("HasNissan");
                    break;
                case "Camaro":
                    PlayerPrefs.SetInt("HasCamaro", 1);
                    unlocked = PlayerPrefs.GetInt("HasCamaro");
                    break;
                case "Mustang":
                    PlayerPrefs.SetInt("HasMustang", 1);
                    unlocked = PlayerPrefs.GetInt("HasMustang");
                    break;
                default:
                    break;
            }
            buy.SetBool("enter", false);
            updaData();
        
        }
    }
    

}
