using UnityEngine;
using System.Collections;

public class FartRender : MonoBehaviour {

	public GameObject _player;
	public float _distanceFromPlayer;

	// Use this for initialization
	void Start () {

		_distanceFromPlayer = 500f;

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 tempPos = _player.transform.position;
		tempPos.z += _distanceFromPlayer;
		transform.position = tempPos;
	
	}
}
