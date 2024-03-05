using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Rider.Unity.Editor;
using UnityEngine;

public class TurretAutoTrack : MonoBehaviour
{
    private AntiMissile MyAntiMissile;
    public Transform target; // The target gameObject to track
    public float trackingSpeed = 5f; // The speed at which the tracking is performed
    public SphereCollider effectiveRadiusCollider; // Collider use to trigger when to activate CIWS and auto aim
    public LayerMask targetMask; // Filter what to target

    [SerializeField]
    private List<Rigidbody> detectedRigidbodies = new List<Rigidbody>(); // Store all detected rigidbody that match targetMask layer


    void Start()
    {
        if(this.GetComponent<AntiMissile>())
            MyAntiMissile = this.GetComponent<AntiMissile>();
    }

    void FixedUpdate()
    {
        if (target != null)
            TrackTarget();
        else
            ResetTurretRotation();

        {
            // Check if any of the stored rigidbodies are no longer detected, and remove them from the list.
            for (int i = detectedRigidbodies.Count - 1; i >= 0; i--)
            {
                if (!detectedRigidbodies[i])
                {
                    detectedRigidbodies.RemoveAt(i);
                }
                else if (!detectedRigidbodies[i].gameObject.activeInHierarchy)
                {
                    detectedRigidbodies.RemoveAt(i);
                }
            }
        }

        if (detectedRigidbodies.Count > 0)
            target = detectedRigidbodies[0].transform;
        else
            target = null;
    }

    private void OnTriggerStay(Collider other)
    {
        // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
        Collider[] colliders = Physics.OverlapSphere(transform.position, effectiveRadiusCollider.radius, targetMask);

        // Go through all the colliders...
        for (int i = 0; i < colliders.Length; i++)
        {
            // ... and find their rigidbody.
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            // If they don't have a rigidbody, go on to the next collider.
            if (!targetRigidbody)
                continue;

            // Store Target Priority by first detected and dont add same reference
            if (detectedRigidbodies.Count > 0)
                foreach (Rigidbody rb in detectedRigidbodies)
                {
                    if (targetRigidbody != rb)
                        detectedRigidbodies.Add(targetRigidbody);
                }
            else
                detectedRigidbodies.Add(targetRigidbody);
        }

        // Always track the first target
        if (detectedRigidbodies.Count > 0)
            target = detectedRigidbodies[0].transform;
    }

    private void OnTriggerExit(Collider other)
    {
        // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
        Collider[] colliders = Physics.OverlapSphere(transform.position, effectiveRadiusCollider.radius, targetMask);

        // Go through all the colliders...
        for (int i = 0; i < colliders.Length; i++)
        {
            // ... and find their rigidbody.
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            // If they don't have a rigidbody, go on to the next collider.
            if (!targetRigidbody)
                continue;

            // Remove the target from our list
            detectedRigidbodies.Remove(targetRigidbody);
            if (detectedRigidbodies.Count > 0)
                target = detectedRigidbodies[0].transform;
            else
                target = null;
        }
    }


    void TrackTarget()
    {
        // Calculate the direction to the target
        Vector3 directionToTarget = (target.position + new Vector3(0f, 0.01f, 0f)) - transform.position;
        directionToTarget.Normalize();

        // Use Raycast to check if the target is visible
        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToTarget, out hit))
        {
            if (hit.collider.CompareTag("AimbotTarget")) // Change "AimbotTarget" to the actual tag of the target gameObject
            {
                // Auto shoot CWIS logic in this section - call the script
                if(MyAntiMissile)
                {
                    MyAntiMissile.FireCWIS();
                }
                
                Debug.Log ("Raycast hit: " + hit.transform.gameObject.name);
            }
        }

        // Rotate towards the target
        Quaternion rotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * trackingSpeed);
        Debug.Log("Turret is rotating at: " + transform.rotation);

        Debug.Log("Turret should ROTATE");
    }

    void ResetTurretRotation()
    {
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, rotation, Time.deltaTime * trackingSpeed);
    }

    // Draw the tracking ray in the Scene view
    private void OnDrawGizmos()
    {
        if (target != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, target.position + new Vector3(0f, 0.5f, 0f));
        }
    }
}
