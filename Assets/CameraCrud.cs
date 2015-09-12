using UnityEngine;
using System.Collections;

public class CameraCrud : MonoBehaviour {

    public GameObject _player;

    Vector3 _targetDestination, _swingNormal, _swingVelocity, _shakeDelta, _swingDelta, _targetPosition;
    float _shakeAmount, _decreaseRate;

	// Use this for initialization
	void Start () {
        transform.position = _player.transform.position;

        // Shake
        _shakeAmount = 0f;
        _decreaseRate = 0f;

        // Swing
        _targetDestination = _player.transform.position;
        _swingNormal = new Vector3();
        _swingVelocity = new Vector3();

        //Shake(0.5f, 0.1f);
	}
	
	// Update is called once per frame
	void LateUpdate () {
        // Move camera with player
        transform.position = _player.transform.position + _shakeDelta;
        UpdateShake();
        UpdateSwing();
	}

    void Shake (float shakeAmount, float decreaseRate) {
        _shakeAmount = shakeAmount;
        _decreaseRate = decreaseRate;
    }

    void Swing (Vector3 targetDestination) {
        _targetDestination = targetDestination;
    }

    void UpdateShake () {
        // Shake
        if (_shakeAmount > 0f)
        {
            _shakeDelta = Random.insideUnitSphere * _shakeAmount;
            _shakeAmount -= Time.deltaTime * _decreaseRate;
        }

        else
        {
            _shakeAmount = 0;
        }
    }

    void UpdateSwing () {
        Vector3 velocity = _player.GetComponent<Rigidbody>().velocity;
        _swingDelta += velocity.normalized * 0.1f;
    }
}
