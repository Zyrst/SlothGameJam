using UnityEngine;
using System.Collections;

public class PowerParent : MonoBehaviour {
    public GameObject _player;

    // Use this for initialization
    void Start()
    {


    }

    void OnEnable()
    {
        _player = GameObject.Find("SlothRider");

    }
	// Update is called once per frame
	void Update () {
        
        //  Vector3.Distance(transform.position, _player.transform.position);
        if (_player != null)
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < 2)
            {
                Activate();
                Debug.Log("PING");
            }
        }
    }
    public virtual void Activate()
    {
        Destroy(gameObject);
    }
}
