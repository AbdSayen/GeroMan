using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] FixedJoystick _joystick;

    [SerializeField] PostProcessVolume _postProcessVolume;
    private Vignette _vignette;
    private ChromaticAberration _chromaticAberration;
    private float t;
    private float t2;
    [SerializeField] private float postSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float aclX = Input.acceleration.x;
        float aclY = Input.acceleration.y;

        if (aclX > 0.5f) aclX = 0.5f;
        if (aclY > 0.5f) aclY = 0.5f;

        _rigidbody.velocity = new Vector3(aclX, 0, aclY + 0.2f) * moveSpeed * Time.deltaTime * 100;
        Rotate();
    }

    private void Rotate()
    {
        _postProcessVolume.profile.TryGetSettings(out _vignette);
        _postProcessVolume.profile.TryGetSettings(out _chromaticAberration);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            t2 = 0;
            if (_vignette.intensity.value < 0.2f)
            {
                _vignette.intensity.value = Mathf.Lerp(_vignette.intensity.value, 0.2f, t);
                _chromaticAberration.intensity.value = Mathf.Lerp(_vignette.intensity.value, 0.45f, t);
                t += Time.deltaTime / postSpeed;
            }
            transform.rotation = Quaternion.LookRotation(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical));
            Time.timeScale = 0.3f;
        }
        else
        {
            t = 0;
            Time.timeScale = 1;
            if (_vignette.intensity.value > 0)
            {
                _vignette.intensity.value = Mathf.Lerp(_vignette.intensity.value, 0.1f, t2);
                _chromaticAberration.intensity.value = Mathf.Lerp(_vignette.intensity.value, 0.1f, t2);
                t2 += Time.deltaTime / postSpeed;
            }
        }
    }
}