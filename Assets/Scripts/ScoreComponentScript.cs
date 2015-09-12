using UnityEngine;
using System.Collections;

/// <summary>
/// As easy as calling 
/// GameObject.Find("ScoreComponent").GetComponent<ScoreComponentScript>().increaseScore();
/// </summary>
public class ScoreComponentScript : MonoBehaviour {

    private int _score;

	// Use this for initialization
	void Start () {
        _score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        GUIStyle textStyle = GUIStyle.none;
        textStyle.fontSize = 32;


        textStyle.normal.textColor = Color.black;
        GUI.Label(new Rect(11, 11, 100, 50), "Score: " + _score, textStyle);
        
        textStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 50), "Score: " + _score, textStyle);
    }

    public void increaseScore() {
        _score++;
    }

    public void resetScore() {
        _score = 0;
    }
}
