using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Volumen : MonoBehaviour {
    public Slider volumeControl;
    public float Volume;
	// Use this for initialization
	void Awake () {
        Volume = PlayerPrefs.GetFloat("Volumen");
        AudioListener.volume = Volume;
	}
	
	// Update is called once per frame
	void Update () {
        AudioListener.volume = volumeControl.value;
        PlayerPrefs.SetFloat("Volumen", Volume);
        Debug.Log(volumeControl.value);
        
	}
}
