using UnityEngine;
using System.Collections;

public class SlothShooter : MonoBehaviour {

    public float _fireDelay = 1;
    float _fireTimer = 0;

    public GameObject _projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (_fireTimer <= 0 && Input.GetMouseButton(0)) {
            GameObject g = Instantiate(_projectile);
            _projectile.transform.position = transform.position;
            g.GetComponent<Rigidbody>().AddForce(0, 0, 10, ForceMode.Impulse);
            _fireTimer = _fireDelay;
        } 
        else
            _fireTimer -= Time.deltaTime;

	}
}
