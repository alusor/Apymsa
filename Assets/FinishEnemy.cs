using UnityEngine;
using System.Collections;

public class FinishEnemy : MonoBehaviour {

    public static int EnemyWin;

    void Awake()
    {
        EnemyWin = 0;
    }
	// Use this for initialization
	void Start () {
        EnemyWin = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Finish.FinishRace == 0) 
        {
            EnemyWin = 1;
        }
    }
}
