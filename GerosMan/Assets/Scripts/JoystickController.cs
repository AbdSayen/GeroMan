using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletTransform;

    public void Attack()
    {
        if (GetComponent<FixedJoystick>().Horizontal != 0 || GetComponent<FixedJoystick>().Vertical != 0)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = bulletTransform.transform.position;
            bullet.transform.rotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
        }
    }
}