using UnityEngine;
using System.Collections;

public class FartRender : MonoBehaviour {

    public GameObject _player;
    public float _distanceFromPlayer;
	public float _minspeed;
	public float _maxspeed;
	public Color _startcolor;

    // Use this for initialization
    void Start() {

        _distanceFromPlayer = 500f;
		_minspeed = 150f;
		_maxspeed = 600f;
		_startcolor = GetComponent<ParticleSystem> ().startColor;

    }

    // Update is called once per frame
    void Update() {

		float temp = _player.GetComponent<Rigidbody>().velocity.z / _player.GetComponent<SlothRider>()._maxSpeed;

		GetComponent<ParticleSystem> ().startSpeed = _minspeed + (_maxspeed - _minspeed) * temp;

		if (temp > 1) {
			temp -= 1;
		} else {
			temp = 0;
		}

		GetComponent<ParticleSystem> ().startColor = _startcolor + new Color (0, temp/2 , temp , 0);

        Vector3 tempPos = _player.transform.position;
        tempPos.z += _distanceFromPlayer;
        transform.position = tempPos;

    }
}

