using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {


    void Awake() {
        PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey("firstPlay"))
        {
            PlayerPrefs.SetInt("firstPlay", 1);
            PlayerPrefs.SetString("SelectionCar", "Jetta");
            PlayerPrefs.SetString("Name", "null");
            PlayerPrefs.SetString("email", "null");
            PlayerPrefs.SetInt("maxScore", 0);
            PlayerPrefs.SetInt("Money",0);
            PlayerPrefs.SetInt("racesPlayed",0);
            PlayerPrefs.SetInt("racesWin",0);
            PlayerPrefs.SetInt("racesLose",0);
            //City = 1
            //Airport = 2
            //AutoDom = 3
            PlayerPrefs.SetInt("lastScene", 1);
            //SetOwnCars
            PlayerPrefs.SetInt("HasJetta", 1);
            PlayerPrefs.SetInt("HasCamaro", 0);
            PlayerPrefs.SetInt("HasDodge", 0);
            PlayerPrefs.SetInt("HasMustang", 0);
            PlayerPrefs.SetInt("HasNissan", 0);
            PlayerPrefs.SetInt("HasHonda", 0);
            //SetOwnScenes
            PlayerPrefs.SetInt("HasCity", 1);
            PlayerPrefs.SetInt("HasAirport", 0);
            PlayerPrefs.SetInt("HasAutoDom", 0);
            //SetVolume
            PlayerPrefs.SetInt("Volumen", 1);
            Debug.Log("DataCreated");
        }
        else {
            Debug.Log("ReadyToPlay");
        }
    }
	// Use this for initialization
	void Start () {
        StartCarrer.startcarrer = 0;
        Finish.FinishRace = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
