using UnityEngine;
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
    public float distToGround;

	// Use this for initialization
	void Start () {
	    _body = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
        _lastPos = Vector3.zero;
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


        if (Input.GetKeyDown(KeyCode.A) && transform.position.x >= -1f && _body.velocity.x == 0)
        {
            _body.AddForce(new Vector3(-10f, 0, 0), ForceMode.Impulse);
            _addedForce = true;
            _lastPos = transform.position;
            impulse = dir.left;
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x <= 1f && _body.velocity.x == 0)
        {
            _body.AddForce(new Vector3(10f, 0, 0), ForceMode.Impulse);
            _addedForce = true;
            _lastPos = transform.position;
            impulse = dir.right;
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Fire the lazer");
            new LaserShot();
        }

        if(Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            _body.AddForce(new Vector3(0, 5f, 0), ForceMode.Impulse);
        }

	}

    public bool OnGround()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.position, -Vector3.up + new Vector3(0 , 0.1f, 0));
        Debug.DrawRay(transform.position, -Vector3.up + new Vector3(0, 0.1f, 0),Color.red, 10f);
        if (Physics.Raycast(ray, out hit, distToGround + 0.1f))
        {
            try
            {
                return true;
            }
            catch (System.NullReferenceException) { return false; }
        }
        else
            return false;
            
    }
}
