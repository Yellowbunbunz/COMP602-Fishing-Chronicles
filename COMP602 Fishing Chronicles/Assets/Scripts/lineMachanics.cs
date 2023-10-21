using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineMachanics : MonoBehaviour
{
    public Transform startPoint; // The first fixed point.
    public Transform endPoint;   // The second fixed point.
    public LineRenderer lineRenderer;

    private void Start()
    {
        // Initialize the LineRenderer positions to the fixed points.
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);
    }
}
