using UnityEngine;
using System.Collections;

public class Slider : MonoBehaviour {
    private Vector3[] _positions = new Vector3[2];
    private Vector3 _target;

    private void Start() {
        _positions[0] = transform.position;
        _positions[1] = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z);
        _target = _positions[0];
    }

    private void Update() {
        MoveSlider();
    }

    private void MoveSlider() {
        if (Vector3.Distance(transform.position, _target) > 0.01f) {
            transform.position = Vector3.MoveTowards(transform.position, _target, 0.2f * Time.deltaTime);
        }
        else {
            SwapTarget();
        }
    }

    private void SwapTarget() {
        if (_target == _positions[0]) _target = _positions[1];
        else _target = _positions[0];
    }
}