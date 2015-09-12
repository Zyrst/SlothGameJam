using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour
{
    public GameObject followObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (followObject != null)
        {
            GetComponent<Transform>().position = followObject.GetComponent<Transform>().position;
        }

    }
}
