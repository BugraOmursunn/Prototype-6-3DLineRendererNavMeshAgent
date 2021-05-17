using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentMover : MonoBehaviour
{
    public static AgentMover instance;
    public Queue<Vector3> path = new Queue<Vector3>();
    private NavMeshAgent _myAgent;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        _myAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        UpdatePath();
    }
    private void UpdatePath()
    {
        if (ShouldSetDestination() == true)
        {
            _myAgent.SetDestination(path.Dequeue());
        }
    }
    private bool ShouldSetDestination()
    {
        if (path.Count == 0)
        {
            return false;
        }
        if (_myAgent.hasPath == false || _myAgent.remainingDistance < 0.5f)
        {
            return true;
        }
        return false;
    }
}
