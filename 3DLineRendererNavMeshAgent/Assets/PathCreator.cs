using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private List<Vector3> pointsList = new List<Vector3>();
    private Camera _mainCamera;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointsList.Clear();
        }
        if (Input.GetMouseButton(0))
        {
            Draw();
        }
        if (Input.GetMouseButtonUp(0))
        {
            AgentMove();
        }
    }

    private void Draw()
    {
        Ray _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hitInfo;

        if (Physics.Raycast(_ray, out _hitInfo, 1000))
        {
            Debug.Log("Burda");
            Vector3 AddList = _hitInfo.point;
            AddList.y = 0.3f;
            pointsList.Add(AddList);
            _lineRenderer.positionCount = pointsList.Count;
            _lineRenderer.SetPositions(pointsList.ToArray());
        }

    }
    private void AgentMove()
    {
        Queue<Vector3> path = new Queue<Vector3>(pointsList);
        AgentMover.instance.path = path;
    }
}
