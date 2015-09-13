﻿using UnityEngine;
using System.Collections;
using System.Linq;

public class Game : MonoBehaviour {

    public GameObject _slothRider;
    public Camera[] _cameras;

	// Use this for initialization
	void Start () {
        Menu();
        _slothRider.gameObject.SetActive(false);
	}

    void OnEnable()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        _slothRider.gameObject.SetActive(true);
        _slothRider.GetComponent<SlothRider>().Reset();
        _cameras[0].gameObject.SetActive(true);
        _cameras[1].gameObject.SetActive(false);
        GetComponentsInChildren<Canvas>(true).FirstOrDefault(x => x.name == "Canvas").gameObject.SetActive(false);
        GameObject.Find("LevelGenerator").gameObject.GetComponent<LevelGenerator>().Reset();

        
    }

    public void Menu()
    {
        _cameras[0].gameObject.SetActive(false);
        _cameras[1].gameObject.SetActive(true);
        GetComponentsInChildren<Canvas>(true).FirstOrDefault(x => x.name == "Canvas").gameObject.SetActive(true);

        _slothRider.transform.position = Vector3.zero;
        _slothRider.SetActive(false);
    }

    public void Exit()
    {

        Application.Quit();
    }

}
