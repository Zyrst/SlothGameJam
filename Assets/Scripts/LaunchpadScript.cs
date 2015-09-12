using UnityEngine;
using System.Collections;

public class LaunchpadScript : MonoBehaviour {

    public float _force = 500f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
    
    void OnCollisionEnter(Collision col) {
        Rigidbody r = col.gameObject.GetComponent<Rigidbody>();

        if (r != null) {
            ContactPoint contact = col.contacts[0];
            r.AddForceAtPosition(-contact.normal * _force, transform.position);
        }

    }
}
