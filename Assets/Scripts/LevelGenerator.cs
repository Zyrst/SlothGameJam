using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

    public int _generateNumber;

    public SlothRider _slothRider;

    public GameObject _startPiece;
    Object[] _levelPieces;
    GameObject _currentPiece;

	// Use this for initialization
	void Start () {
        if (_slothRider == null)
            Debug.LogError("PLAYER REFERENCE CANNOT BE NULL");

        _levelPieces = Resources.LoadAll("Level/Regular");
        
        _currentPiece = Instantiate(_startPiece);
        _currentPiece.transform.position = transform.position;
        _currentPiece.GetComponent<LevelPieceScript>().setGenerator(this);

        for (int i = 0; i < _generateNumber; i++)
            instantiateRandom();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void instantiateRandom() {
        int i = Random.Range(0, _levelPieces.Length);
        GameObject _nextPiece = (GameObject)_levelPieces[i];
        GameObject spawned = Instantiate(_nextPiece);

        spawned.transform.position = _currentPiece.transform.position + new Vector3(0, 0, 
            _currentPiece.GetComponent<LevelPieceScript>().getSize().z / 2 + 
            spawned.GetComponent<LevelPieceScript>().getSize().z / 2);

        _currentPiece = spawned;
        _currentPiece.GetComponent<LevelPieceScript>().setGenerator(this);
    }

    public void passedPiece(LevelPieceScript p) {
        instantiateRandom();
        Destroy(p.transform.gameObject);
    }
}
