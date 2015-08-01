using UnityEngine;
using System.Collections;

/*
 * TODO: read up on each:
 * 
 * 1.	Grip is a term describing the total cornering envelope of a race car by the friction of the tire as a function of i.a. 
 * 		the mass of the machine and the downforce generated.
 *
 * 2.	http://en.wikipedia.org/wiki/Acceleration
 * 3.	http://phors.locost7.info/phors01.htm
 *
 *
 *The RPM to Linear Velocity formular is : 
  v = r × RPM × 0.10472

Where:
  v: Linear velocity, in m/s
  r: Radius, in meter
  RPM: Angular velocity, in RPM (Rounds per Minute)
 *
 */

public class CarEngine : MonoBehaviour {

	private CarMods carModsScript;
	private Rigidbody2D rigidBody;

	private float _power = 0f;
	public int _gear = 0; //set to public temporarily for testing
	private float _engineRPM = 0f;
	
	private float _wheelTorque;
	
	private	float minRPM = 200f;
	private float peakRPM = 800f;
	private float maxRPM = 1000f;
	
	private float minTorque = 10f;
	private float maxTorque = 30f;
	
	private float[] gearRatios = {4.23f, 2.47f, 1.67f, 1.23f, 1.0f, 0.79f};//TODO: Make need to make it 6 gears, I'll check for better ger ratios.
	private float tempNum = 0.0f;

	void Awake ()
	{
		carModsScript = GetComponent<CarMods>();
		rigidBody = GetComponent<Rigidbody2D>();
		_power = 0.05f;
	}

	void Update ()
	{      
		// Update the internals of the engine
		UpdateEngine();
		
		// Set torque on wheels and steering etc
		UpdateCar();
	}

	public void UpdateCar()
	{
		tempNum = _wheelTorque * _engineRPM * 0.10472f * Time.deltaTime; //Magic number is from formula.
		Debug.Log("tempNum is " + tempNum);
		Debug.Log("_wheelTorque is " + _wheelTorque);
		//Debug.Log("_engineRPM is " + _engineRPM);
		transform.Translate(Vector3.right * (carModsScript.acceleration + tempNum));
		//rigidBody.velocity = new Vector2( (carModsScript.acceleration + tempNum), rigidBody.velocity.y);
	}
	
	public void UpdateEngine()
	{
		// Reset wheel torque to 0 every frame
		_wheelTorque = 1f;
		
		// Find RPM of wheels
		float wheelRPM = 0f;
		/*
		foreach (WheelCollider w in powerWheels) //TODO: need to assign a static variable for the wheels
		{
			wheelRPM += w.rpm;
		}
		wheelRPM /= powerWheels.Length;
		*/
		//Let see if I can replace the above code with my own:
		wheelRPM = 4 * carModsScript.grip; //There is 4 wheels

		if (_gear > 0)
		{
			// How fast the shaft is turning at the engine end
			float rpmToEngine = wheelRPM * gearRatios[_gear];
			
			// Don't instantly set the engine to that RPM - the engine takes a while to get there.
			// This should be done better, but a lerp or something works now.
			_engineRPM = Mathf.MoveTowards(_engineRPM, rpmToEngine, Time.deltaTime * (maxRPM - minRPM));
			
			// Torque to the wheels is a function of the RPM, multiplied by the power. The gear then multiplies this torque again.
			_wheelTorque = GetEngineTorqueFromRPM(_engineRPM) * _power * gearRatios[_gear];               
		}
		else
		{
			// Neutral gear, simulate the engine idle. Lerp sucks, but it's fine for now.
			float targetRPM = Mathf.Lerp(minRPM, maxRPM, _power);
			_engineRPM += (targetRPM - _engineRPM) * Time.deltaTime;
		}
	}
	
	
	float GetEngineTorqueFromRPM(float rpm)
	{
		if (rpm < minRPM)
		{
			// 0 output below minimum RPM - we've stalled
			return 0f;
		}
		else if (rpm < peakRPM)
		{
			// Ramp up to the peak RPM value
			float range = rpm - minRPM;
			float x = range / (peakRPM - minRPM);
			
			return Mathf.Lerp(minTorque, maxTorque, x);
		}
		else if (rpm < maxRPM)
		{
			// Ramp down from peak to max
			float range = rpm - peakRPM;
			float x = range / minRPM;
			return Mathf.Lerp(maxTorque, minTorque, x);
		}
		else
		{
			// Spinning faster than max - negative torque!
			return -minTorque;
		}
	}
}
