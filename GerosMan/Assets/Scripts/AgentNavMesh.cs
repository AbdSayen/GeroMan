using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentNavMesh : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent _agent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        _agent.destination = player.transform.position;
    }
}
