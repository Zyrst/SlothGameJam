using UnityEngine;
using System.Collections;

public class SlothCamera : MonoBehaviour {

    public GameObject _player;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = _player.transform.position;
	}
}
