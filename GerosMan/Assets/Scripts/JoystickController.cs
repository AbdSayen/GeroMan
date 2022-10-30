using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletTransform;

    [SerializeField] private GameObject attackBtn;
    private bool shootReady = true;

    public void Attack()
    {
        if ((GetComponent<FixedJoystick>().Horizontal != 0 || GetComponent<FixedJoystick>().Vertical != 0) && shootReady == true)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = bulletTransform.transform.position;
            bullet.transform.rotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
            StartCoroutine(SetShootReady());
        }
    }

    private IEnumerator SetShootReady()
    {
        attackBtn.GetComponent<Image>().color = Color.red;
        shootReady = false;
        yield return new WaitForSeconds(2f);
        attackBtn.GetComponent<Image>().color = Color.green;
        shootReady = true;
    }
}