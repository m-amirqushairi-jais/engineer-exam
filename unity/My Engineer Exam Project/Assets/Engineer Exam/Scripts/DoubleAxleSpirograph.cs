using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAxleSpirograph : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int numPoints = 500;
    public float R = 50f; // Radius of the fixed circle
    public float r = 20f; // Radius of the rolling circle
    public float d = 10f; // Distance from the center of rolling circle to drawing point
    public float speed = 0.05f;


    public float drawTimeInterval = 0.1f;
    int drawnPoint = 0;
    float angle = 0f;
    float timer = 0f;


    private void Start()
    {
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer component not assigned!");
            return;
        }

        lineRenderer.positionCount = 0;
        //DrawSpirograph();
    }

    void FixedUpdate()
    {
        if(timer < drawTimeInterval)
        timer += Time.deltaTime;
        else if (drawnPoint < numPoints)
        {
            DrawSpirograph();
        }
    }

    private void DrawSpirograph()
    {        
            float x = (R - r) * Mathf.Cos(angle) + d * Mathf.Cos(((R - r) / r) * angle);
            float y = (R - r) * Mathf.Sin(angle) - d * Mathf.Sin(((R - r) / r) * angle);
            
            lineRenderer.positionCount = drawnPoint+1;
            lineRenderer.SetPosition(drawnPoint, new Vector3(x, y, 0));
            

            angle += speed;
            drawnPoint++;
            timer = 0;
    }
}