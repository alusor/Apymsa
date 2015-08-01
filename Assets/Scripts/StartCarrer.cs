using UnityEngine;
using System.Collections;

public class StartCarrer : MonoBehaviour {

    public static int startcarrer;
    public AudioClip GoSound;
	// Use this for initialization
    void Awake() {
        startcarrer = 0; 
    }

    void Start () {
            
	}

    public void BeginCount() {
        StartCoroutine(Race());
    }

    IEnumerator Race()
    {
        GameObject Pedal = GameObject.Find("Pedal");
        Pedal.SetActive(false);
        Animator anim = GetComponent<Animator>();
        anim.enabled = true;
        yield return new WaitForSeconds(0.5f);
        GetComponent<AudioSource>().clip = GoSound;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3.5f);
        Debug.Log("GO!");
        startcarrer = 1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
