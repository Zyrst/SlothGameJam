using UnityEngine;
using System.Collections;

public class lavascript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		SlothRider s = collision.gameObject.GetComponent<SlothRider>();
		if (s != null)
			s.Kill();
	}
}
