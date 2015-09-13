using UnityEngine;
using System.Collections;

public class DirectionalLightScript : MonoBehaviour {

	public float _rotationspeed;

	// Use this for initialization
	void Start () {

		_rotationspeed = 20f;
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 newRot = new Vector3((_rotationspeed*Time.deltaTime),(_rotationspeed*Time.deltaTime) , (_rotationspeed*Time.deltaTime));
		transform.Rotate (newRot);
	
	}
}
