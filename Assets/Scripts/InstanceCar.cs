using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstanceCar : MonoBehaviour {
    public GameObject carPlayer;
    public GameObject[] enemeArray;
    public GameObject enemyPlayer;
    public string namePlayer;
    public Transform initialPlayerPosition;
    public Transform initialEnemyPosition;
    public Button nextGearButton;
    private DashGUI setValues;
    private CameraMov setCam;
    
	// Use this for initialization
    void Awake() {
        //PlayerPrefs.SetString("SelectionCar", "Mustang");
        if (PlayerPrefs.HasKey("SelectionCar"))
            namePlayer = PlayerPrefs.GetString("SelectionCar"); 

        carPlayer = Instantiate(Resources.Load(namePlayer),new Vector3(initialPlayerPosition.position.x,initialPlayerPosition.position.y,0),Quaternion.identity) as GameObject;
        carPlayer.transform.localScale = new Vector3(.5f,.5f);
        int rand = Random.Range(0, 4);
        enemyPlayer = Instantiate(enemeArray[rand], initialEnemyPosition.position, Quaternion.identity) as GameObject;

    }
	void Start () {
        setValues = FindObjectOfType<DashGUI>();
        setValues.vehicleControl = carPlayer.GetComponent<SimpleControlVehicle>();
        setCam = FindObjectOfType<CameraMov>();
        setCam.other = carPlayer.transform;
        nextGearButton.onClick.AddListener(() => carPlayer.GetComponent<SimpleControlVehicle>().nextVgear());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
