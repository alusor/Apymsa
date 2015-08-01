using UnityEngine;
using System.Collections;

public class CarSimpleMovement : MonoBehaviour {

    private float xspeep = 0f;
    public float power = 0.02f;
    float friction = 0.95f;

    bool go = false;

    public float fuel = 100;

    private int GearState;
    float speed;

    void Start() {
        GearState = 0;
    }
	// Use this for initialization
    void FixedUpdate()
    {
        if (go)
        {
            xspeep -= power;
            fuel -= power;
            
            Debug.Log(GetComponent<Rigidbody2D>().velocity);
            Gear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){
            if (GearState <= 4)
            {
                GearState = GearState + 1;
                Debug.Log(GearState);
            }
        }

        if (Input.GetKeyDown("s") && GearState > 0)
        {
            go = true;
        }
        if (Input.GetKeyUp("s"))
        {
            go = false;
        }

        if (fuel < 0)
        {
            xspeep = 0;
        }

        xspeep *= friction;
        transform.Translate(Vector3.right * -xspeep);

    }

    void Gear()
    {
        if (GearState == 2) {
            power = 0.03f;
        }
        if (GearState == 3)
        {
            power = 0.04f; 
        }
        if (GearState == 4)
        {
            power = 0.05f;
        }
        if (GearState == 5)
        {
            power = 0.06f;
        } 
    }
}
