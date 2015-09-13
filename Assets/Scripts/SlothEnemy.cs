using UnityEngine;
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
        Sounds.OneShot(Sounds.Instance._sounds._deadSloth);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "SlothRider")
        {
            col.gameObject.GetComponent<SlothRider>().Kill();
            Kill();
        }
        else if(col.gameObject.name == "Projectile(Clone)")
        {
            Kill();
        }
    }
}
