using UnityEngine;
using System.Collections;

public class CameraCrud : MonoBehaviour {

    public Transform _camTransform;

    Vector3 _originalPosition, _targetDestination, _swingNormal, _swingVelocity;
    float _shakeAmount, _decreaseRate, counter;

	// Use this for initialization
	void Start () {
        // Shake
        _originalPosition = _camTransform.localPosition;
	    _camTransform = GetComponent(typeof(Transform)) as Transform;
        _shakeAmount = 0f;
        _decreaseRate = 0f;

        //Shake(0.5f, 0.3f);

        // Swing
        _targetDestination = _originalPosition;
        _swingNormal = new Vector3();
        _swingVelocity = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
        if (counter > 600) {
            Swing(Random.insideUnitSphere * 5);
        }

        counter++;

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
            _camTransform.localPosition = _originalPosition + Random.insideUnitSphere * _shakeAmount;
            _shakeAmount -= Time.deltaTime * _decreaseRate;
        }

        else
        {
            _shakeAmount = 0;
        }
    }

    void UpdateSwing () {
        Vector3 distance = _targetDestination - _camTransform.localPosition;
        float distanceFloat = Vector3.Distance(_targetDestination, _camTransform.localPosition);

        _swingVelocity += distance.normalized * distanceFloat * Time.deltaTime;
        _swingVelocity -= new Vector3(2, 2, 2) * Time.deltaTime;

        _camTransform.localPosition += _swingVelocity * Time.deltaTime;
    }
}
