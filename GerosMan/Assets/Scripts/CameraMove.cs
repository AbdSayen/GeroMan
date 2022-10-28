using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform player;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, 9, player.transform.position.z - 8), 0.5f * Time.deltaTime);
    }
}
