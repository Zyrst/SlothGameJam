using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	public float _lifetime;
	public float _expansion;
	public float _startLightIntensity;
	public float _startEmissionRate;




	// Use this for initialization
	void Start () {

		_lifetime = 1f;
		_expansion = 30f;
		_startLightIntensity = GetComponent<Light> ().intensity;
		_startEmissionRate = GetComponent<ParticleSystem> ().emissionRate;

		GetComponent<Light> ().range = 0;


	}
	
	// Update is called once per frame
	void Update () {

		//GetComponent<Light> ().range += Time.deltaTime * _expansion;

		if (_lifetime - 0.9f > 0) {
			GetComponent<ParticleSystem> ().emissionRate = _startEmissionRate * _lifetime - 0.9f;
		} else {
			GetComponent<ParticleSystem> ().emissionRate = 0;
		}
		float tempIncrease = (_expansion - GetComponent<Light> ().range) * 0.05f;
		GetComponent<Light> ().range += tempIncrease;
		GetComponent<Light> ().intensity = _lifetime * _startLightIntensity;

		_lifetime -= Time.deltaTime;
		if (_lifetime <= 0) {
			Destroy(gameObject);
		}

	
	}
}
