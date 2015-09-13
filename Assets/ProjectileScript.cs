using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

    GameObject _player;
    public GameObject _explosionPrefab;

	// Use this for initialization
	void Start () {
        if (_explosionPrefab == null)
            Debug.LogError("You forgot explosion prefab reference. You dofus!");
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, _player.transform.position) > 500)
            Destroy(this.transform.gameObject);
	}

    void OnCollisionEnter(Collision collision) {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
    }

    public void setPlayer(GameObject player) {
        _player = player;
    }
}
