﻿using UnityEngine;
using System.Collections;

public class SlothRider : MonoBehaviour {

    public float _speed;
    public float _maxSpeed;

    [HideInInspector]
    public Rigidbody _body;
    [HideInInspector]
    public bool _addedForce = false;
    Vector3 _lastPos;
    enum dir { left, right };
    dir impulse = dir.left;

    public float travelDist = 10f;
	// Use this for initialization
	void Start () {
	    _body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(_body.velocity.z <= _maxSpeed)
            _body.AddForce(new Vector3(0, 0, _speed * Time.deltaTime), ForceMode.Acceleration);

        if (_addedForce)
        {
            switch (impulse)
            {
                case dir.left:
                    if (transform.position.x < (_lastPos.x - travelDist))
                    {
                        float z = _body.velocity.z;
                        _body.velocity = new Vector3(0, 0, z);
                        _addedForce = false;
                    }
                    break;
                case dir.right:
                    if (transform.position.x > (_lastPos.x + travelDist))
                    {
                        float z = _body.velocity.z;
                        _body.velocity = new Vector3(0, 0, z);
                        _addedForce = false;
                    }
                    break;
            }
            
        }


        if (Input.GetKeyDown(KeyCode.A) && transform.position.x >= -1f)
        {
            _body.AddForce(new Vector3(-10f, 0, 0), ForceMode.Impulse);
            _addedForce = true;
            _lastPos = transform.position;
            impulse = dir.left;
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x <= 1f)
        {
            _body.AddForce(new Vector3(10f, 0, 0), ForceMode.Impulse);
            _addedForce = true;
            _lastPos = transform.position;
            impulse = dir.right;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _body.AddForce(new Vector3(0, 5f, 0), ForceMode.Impulse);
        }

	}
}
