using UnityEngine;
using System.Collections;

public class LevelPieceScript : MonoBehaviour {

    BoxCollider _boundingBox;
    LevelGenerator _generator;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public Vector3 getSize() {
        _boundingBox = GetComponent<BoxCollider>();
        if (_boundingBox == null)
            Debug.LogError("Piece must have bounding box");

        return _boundingBox.size;
    }

    public void setGenerator(LevelGenerator gen) {
        _generator = gen;
    }

    void OnTriggerExit(Collider other) {
        if (other.GetComponent<SlothRider>())
            _generator.passedPiece(this);
    }
}
