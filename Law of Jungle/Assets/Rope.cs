using System;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject linkPrefab;
    public int linkCount = 10;
    LineRenderer lineRenderer;
    public float lineWidth = 0.1f;

    void Start()
    {
        GenerateRope();
        //DrawRope();
    }

    private void GenerateRope()
    {
        Rigidbody2D previousRb = hook;
        for (int i = 0; i < linkCount; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRb;

            previousRb = link.GetComponent<Rigidbody2D>();
        }
    }

    private void DrawRope()
    {
        float lineWidth = this.lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[linkCount];
        for (int i = 0; i < linkCount; i++)
        {
            ropePositions[i] = transform.position;
        }
        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }

}
