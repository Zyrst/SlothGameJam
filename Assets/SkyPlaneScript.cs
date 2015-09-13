using UnityEngine;
using System.Collections;

public class SkyPlaneScript : MonoBehaviour {

	public float _rotationspeed;

	public float maxPulse = 0.7f;
	public float pulse = 0f;
	public float maxScale = 1000f;
	public float normalScale = 1f;
	public float scale = 1f;

	// Use this for initialization
	void Start () {
	
		_rotationspeed = 0.4f;
		maxPulse = 0.7f;
		pulse = 0f;
		maxScale = 1.01f;
		normalScale = 1f;
		scale = 1f;
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
