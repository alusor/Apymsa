using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {
    public float moveSpeed;
    private Rigidbody2D r;
    private WheelJoint2D wheel1;
	// Use this for initialization
	void Start () {
        r = GetComponent<Rigidbody2D>();
        wheel1 = GetComponent<WheelJoint2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow)) {
            r.velocity = new Vector2(moveSpeed, r.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            r.velocity = new Vector2(-moveSpeed, r.velocity.y); 
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            r.velocity = new Vector2(r.velocity.x,13f);
        }
        //r.AddForce(10, 0);
	}

}
