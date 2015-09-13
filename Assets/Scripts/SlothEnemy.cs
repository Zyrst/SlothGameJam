﻿using UnityEngine;
using System.Collections;

public class SlothEnemy : MonoBehaviour {

    public GameObject _blood;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Spawn(Vector3 position_)
    {
        transform.position = position_;
    }

    public void Kill()
    {
        GameObject.Find("ScoreComponent").GetComponent<ScoreComponentScript>().increaseScore();
        Instantiate(_blood).transform.position = transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "SlothRider")
        {
            Debug.Log("hit by player");
            col.gameObject.GetComponent<SlothRider>().Kill();
        }
        else if(col.gameObject.name == "Projectile")
        {
            Kill();
        }
    }
}
