using UnityEngine;
using System.Collections;

public class CameraMov : MonoBehaviour {
    public Transform other;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(other.position.x + 4,transform.position.y,-10);
        if (Finish.FinishRace == 1) { 
            GameObject Meta = GameObject.FindGameObjectWithTag("Finish");

            transform.position = new Vector3(Meta.transform.position.x, transform.position.y,-10);
        }
	}
}
