using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] FixedJoystick _joystick;

    private void Update()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = new Vector3(Input.acceleration.x, 0, Input.acceleration.y) * moveSpeed * Time.deltaTime * 100;
        Rotate();
    }

    private void Rotate()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical));
            Time.timeScale = 0.3f;
        }
        else Time.timeScale = 1;
    }
}
