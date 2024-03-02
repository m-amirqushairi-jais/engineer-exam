using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 5f;
    private Transform target;

    private Rigidbody rb;
    private Vector3 initialPosition;
    private Vector3 controlPosition;

    private Transform spawnPoint;
    private Transform controlPoint;
    private Transform tempTargetPoint;

    void Awake()
    {
        this.GetComponent<CapsuleCollider>().isTrigger = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    public void InitReference(Transform _spawnPoint, Transform _controlPoint, Transform _tempTargetPoint, Transform _target)
    {
        spawnPoint = _spawnPoint;
        controlPoint = _controlPoint;
        tempTargetPoint = _tempTargetPoint;
        target = _target;

        initialPosition = spawnPoint.position;
        controlPosition = controlPoint.position;

        LaunchMissile();
    }

    private float timer = 0;
    public float timeLimit = 2.0f;

    bool isLaunched = false;
    float bezierClock = 0f;

    public void LaunchMissile()
    {
        if (!isLaunched)
        {
            timer = 0;
            bezierClock = 0;
            isLaunched = true;
        }
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (isLaunched)
        {
            //on launch, give some character or attitude to the missile - simulate rocket launch initiation
            if (target != null && timer < timeLimit)
            {
                // Calculate the direction to the bezier tempTarget position first (go up)
                Vector3 direction = tempTargetPoint.position - transform.position;
                direction.Normalize();

                // Rotate towards the target
                Quaternion toRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

                // Move the missile along the Bezier curve
                float t = bezierClock * 0.1f * speed; // Adjust the multiplier to control the curve
                Vector3 bezierPosition = BezierCurve(initialPosition, controlPoint.position, tempTargetPoint.position, t);
                bezierClock += Time.deltaTime;
                rb.MovePosition(bezierPosition);
            }
            else
            {
                // Calculate the direction to the target
                Vector3 direction = target.position - transform.position;
                direction.Normalize();

                // Rotate towards the target
                Quaternion toRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

                // Move the missile forward
                rb.velocity = transform.forward * speed;
                this.GetComponent<CapsuleCollider>().isTrigger = true;
            }
        }
    }

    // Bezier curve calculation function
    Vector3 BezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * tempTargetPoint.position;

        return p;
    }

    // Draw the Bezier curve as Gizmo
    void OnDrawGizmos()
    {
        initialPosition = spawnPoint.position;
        controlPosition = controlPoint.position;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(initialPosition, controlPosition);
        Gizmos.DrawLine(controlPosition, tempTargetPoint.position);

        Gizmos.color = Color.green;
        Vector3 lastPoint = initialPosition;
        for (float t = 0.05f; t <= 1; t += 0.05f)
        {
            Vector3 nextPoint = BezierCurve(initialPosition, controlPosition, tempTargetPoint.position, t);
            Gizmos.DrawLine(lastPoint, nextPoint);
            lastPoint = nextPoint;
        }
    }
}
