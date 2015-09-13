using UnityEngine;
using System.Collections;

public class SlothShooter : MonoBehaviour {

    public float _projectileSpeed = 50;
    public float _fireDelay = 1;
    float _fireTimer = 0;
    public Camera camera;

    public GameObject _projectile;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (_fireTimer <= 0 && Input.GetMouseButton(0)) {
            /*GameObject g = Instantiate(_projectile);
            g.transform.position = transform.position + new Vector3(0, 0, 2);

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            Vector3 s = transform.position + ray.direction + new Vector3(0, 0.25f, 0);
            Rigidbody r = g.GetComponent<Rigidbody>();
            //r.velocity = transform.GetComponent<Rigidbody>().velocity;
            r.AddForce(s.x * _projectileSpeed, s.y * _projectileSpeed, s.z * _projectileSpeed, ForceMode.Impulse);
            */

            GameObject g = Instantiate(_projectile);
            g.transform.position = transform.position + new Vector3(0, 0, 2);
            Rigidbody r = g.GetComponent<Rigidbody>();
            r.velocity = transform.GetComponent<Rigidbody>().velocity;
            r.AddForce(0, 0, _projectileSpeed, ForceMode.Impulse);

            _fireTimer = _fireDelay;
        } 
        else
            _fireTimer -= Time.deltaTime;
	}
}
