using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	public float _lifetime;
	public float _expansion;




	// Use this for initialization
	void Start () {

		_lifetime = 1f;
		_expansion = 120f;

		GetComponent<Light> ().range = 0;


	}
	
	// Update is called once per frame
	void Update () {

		//GetComponent<Light> ().range += Time.deltaTime * _expansion;


		float tempIncrease = (_expansion - GetComponent<Light> ().range) * 0.05f;
		GetComponent<Light> ().range += tempIncrease;


		_lifetime -= Time.deltaTime;
		if (_lifetime <= 0) {
			Destroy(gameObject);
		}

	
	}
}
