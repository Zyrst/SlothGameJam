using UnityEngine;
using System.Collections;
using System.Linq;

public class SlothRider : MonoBehaviour {

    public float _speed;
    public float _maxSpeed;

    [HideInInspector]
    public Rigidbody _body;
    [HideInInspector]
    public bool _addedForce = false;
    Vector3 _lastPos;
    public Vector3 _startPos;
    enum dir { left, right };
    dir impulse = dir.left;

    public float _travelDist = 10f;
    public float _distToGround;
    float xPos;

    public bool _dead = false;

	// Use this for initialization
	void Start () {
       
	}

    void OnEnable()
    {
        _body = GetComponent<Rigidbody>();
        _distToGround = GetComponent<Collider>().bounds.extents.y;
        _lastPos = Vector3.zero;
        _startPos = transform.position;
        xPos = transform.position.x;
        
    }
	
	// Update is called once per frame
    void Update()
    {
        if (!_dead)
        {
            //Debug.Log(_body.velocity.z);
            if (_body.velocity.z <= _maxSpeed)
            {
                _body.AddForce(new Vector3(0, 0, _speed * Time.deltaTime), ForceMode.Acceleration);
            }


            if (_body.velocity.z > _maxSpeed + 50f)
            {
                _body.velocity *= 0.9f;

            }


            if (_addedForce)
            {
                switch (impulse)
                {
                    case dir.left:
                        xPos = Mathf.Lerp(xPos, xPos - _travelDist, Time.deltaTime);
                        if (transform.position.x <= (_lastPos.x - _travelDist))
                        {
                            _addedForce = false;
                            xPos = Mathf.Round(xPos);
                        }
                        break;
                    case dir.right:
                        xPos = Mathf.Lerp(xPos, xPos + _travelDist, Time.deltaTime * 2f);
                        if (transform.position.x >= (_lastPos.x + _travelDist))
                        {
                            _addedForce = false;
                            xPos = Mathf.Round(xPos);
                        }
                        break;
                }

            }


            if (Input.GetKeyDown(KeyCode.A) && transform.position.x > (_startPos.x - _travelDist) && !_addedForce)
            {
                _addedForce = true;
                _lastPos = transform.position;
                impulse = dir.left;
            }
            if (Input.GetKeyDown(KeyCode.D) && transform.position.x < (_startPos.x + _travelDist) && !_addedForce)
            {
                _addedForce = true;
                _lastPos = transform.position;
                impulse = dir.right;
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                _body.AddForce(new Vector3(0f, -10f, 0f), ForceMode.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Fire the lazer");
            }

            if (Input.GetKeyDown(KeyCode.Space) && OnGround())
            {
                _body.AddForce(new Vector3(0, 5f, 0), ForceMode.Impulse);
            }


            Vector3 pos = transform.position;
            pos.x = xPos;
            transform.position = pos;

            if (CheckOutofBounds())
                Kill();
        }
    }

    public bool OnGround()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.position, -Vector3.up + new Vector3(0 , 0.1f, 0));
        Debug.DrawRay(transform.position, -Vector3.up + new Vector3(0, 0.1f, 0),Color.red, 10f);
        if (Physics.Raycast(ray, out hit, _distToGround + 0.1f))
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
    

    public bool CheckOutofBounds()
    {
        return transform.position.y <= -300;
    }

    public void Kill()
    {
        _dead = true;   //Fuck doing updates
        Debug.Log("Dead sloth rider");
        _body.useGravity = false;   //Make it hover
        _body.velocity = new Vector3(0, 0, 0);  //Reset physics
        _body.angularVelocity = new Vector3(0, 0, 0);
        gameObject.GetComponentsInChildren<Canvas>(true).FirstOrDefault(x => x.name == "DeadMenu").gameObject.SetActive(true);
        
    }
   
    public void Reset()
    {
        transform.position = Vector3.zero;  //Set it in Zero (doesn't work on X : S)
        _body.useGravity = true;
        GetComponent<ScoreComponentScript>().resetScore(); 

        gameObject.GetComponentsInChildren<Canvas>(true).FirstOrDefault(x => x.name == "DeadMenu").gameObject.SetActive(false);
        _dead = false;
        
    }

}
