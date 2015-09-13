using UnityEngine;
using System.Collections;

public class SkyPlaneScript : MonoBehaviour {

	public float _rotationspeed;

	public float maxPulse;
	public float pulse;
	public float maxScale;
	public float normalScale;
	public float scale;

	// Use this for initialization
	void Start () {
	
		_rotationspeed = 0.4f;
		maxPulse = 0.47244094488f;
		pulse = 0f;
		maxScale = 2.02f;
		normalScale = 2f;
		scale = 2f;
	}
	
	// Update is called once per frame
	void Update () {

		scale += (normalScale - scale) * 0.1f;


		pulse += Time.deltaTime;
		if (pulse > maxPulse) {
			pulse -= maxPulse;
			scale = maxScale;
		}

		Vector3 newScale = new Vector3 (scale, scale, 0);
		transform.localScale = newScale;


		Vector3 newRot = new Vector3(0,0 , (_rotationspeed*Time.deltaTime));
		transform.Rotate (newRot);
	
	}
}
