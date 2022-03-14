using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DebugMode : MonoBehaviour
{
    // Zone des variables
    NavMeshAgent agent;
    public bool velocity;
    public bool VelocityObjectif;
    public bool path;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void OnDrawGizmos()
    {
        if (velocity)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + agent.velocity);
        }

        if (VelocityObjectif)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + agent.desiredVelocity);
        }

        if (path)
        {
            Gizmos.color = Color.black;
            var agentpath = agent.path;
            Vector3 prevCorner = transform.position;
            foreach(var corner in agentpath.corners)
            {
                Gizmos.DrawLine(prevCorner, corner);
                Gizmos.DrawSphere(corner, 0.1f);
                prevCorner = corner;
            }
        }

    }
}
