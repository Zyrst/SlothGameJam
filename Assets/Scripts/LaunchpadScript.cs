using UnityEngine;
using System.Collections;

public class LaunchpadScript : MonoBehaviour {

    public Vector3 _launchDir = new Vector3(0, 1, 0);
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

    void OnTriggerEnter(Collider col) {
        Debug.Log(col);
        Rigidbody r = col.gameObject.GetComponent<Rigidbody>();
        Sounds.OneShot(Sounds.Instance._sounds._speedBoost);
        if (r != null) {
            r.AddForceAtPosition(_launchDir.normalized * _force, transform.position);
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (transform.position + _launchDir.normalized * 2));
    }
}
