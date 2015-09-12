using UnityEngine;
using System.Collections;

public class FartRender : MonoBehaviour {

	public GameObject _player;
	public float _distanceFromPlayer;
    public float minSpeed;
    public float maxSpeed;


	// Use this for initialization
	void Start () {

		_distanceFromPlayer = 500f;
        minSpeed = 150f;
        maxSpeed = 600f;
        GetComponent<ParticleSystem>().startSpeed = minSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        float temp = _player.GetComponent<Rigidbody>().velocity.z;
        temp /= _player.GetComponent<SlothRider>()._maxSpeed;
        GetComponent<ParticleSystem>().startSpeed = minSpeed + (maxSpeed - minSpeed) * temp;
       // GetComponent<ParticleSystem>().startSpeed = _player.GetComponent<Rigidbody>().velocity.z;
        Vector3 tempPos = _player.transform.position;
		tempPos.z += _distanceFromPlayer;
		transform.position = tempPos;
        Debug.Log(_player.GetComponent<Rigidbody>().velocity.z);
	
	}
}
