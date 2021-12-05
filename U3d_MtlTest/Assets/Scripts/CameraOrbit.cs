using System;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _distance = 10.0f;

    [SerializeField] private float _xSpeed = 250.0f;
    [SerializeField] private float _ySpeed = 120.0f;

    [SerializeField] private float _yMinLimit = -20;
    [SerializeField] private float _yMaxLimit = 80;

    private float _x = 0.0f;
    private float _y = 0.0f;

    private float _offset;
    private float _prevDistance;
    private Vector2Int _size = new Vector2Int(-1, -1);

    public void Init(float offset)
    {
        _offset = offset;
    }

    private void Start()
    {
        var angles = transform.eulerAngles;
        _x = angles.y;
        _y = angles.x;
    }

    public void ChangeZoom(int? x, int? z)
    {
        if (x.HasValue) _size.x = x.Value;
        if (z.HasValue) _size.y = z.Value;

        if (_size.x < 0 || _size.y < 0) return;

        var biggest = _size.x > _size.y ? _size.x : _size.y;
        _distance = biggest + biggest * _offset + 5;
    }


    void LateUpdate()
    {
        if (_distance < 2) _distance = 2;
        _distance -= Input.GetAxis("Mouse ScrollWheel") * 2;
        if (_target && (Input.GetMouseButton(0) || Input.GetMouseButton(1)))
        {
            var pos = Input.mousePosition;
            var dpiScale = 1f;
            if (Screen.dpi < 1) dpiScale = 1;
            if (Screen.dpi < 200) dpiScale = 1;
            else dpiScale = Screen.dpi / 200f;

            if (pos.x < 380 * dpiScale && Screen.height - pos.y < 250 * dpiScale) return;

            _x += Input.GetAxis("Mouse X") * _xSpeed * 0.02f;
            _y -= Input.GetAxis("Mouse Y") * _ySpeed * 0.02f;

            _y = ClampAngle(_y, _yMinLimit, _yMaxLimit);
            var rotation = Quaternion.Euler(_y, _x, 0);
            var position = rotation * new Vector3(0.0f, 0.0f, -_distance) + _target.transform.position;
            transform.rotation = rotation;
            transform.position = position;
        }

        if (Math.Abs(_prevDistance - _distance) > 0.001f)
        {
            _prevDistance = _distance;
            var rot = Quaternion.Euler(_y, _x, 0);
            var po = rot * new Vector3(0.0f, 0.0f, -_distance) + _target.transform.position;
            transform.rotation = rot;
            transform.position = po;
        }
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}