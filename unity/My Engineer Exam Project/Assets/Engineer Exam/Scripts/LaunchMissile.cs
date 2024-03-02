using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class LaunchMissile : MonoBehaviour
{
    public int m_PlayerNumber = 1;              // Used to identify the different players. 
    public Rigidbody m_Missile;                 // Rigidbody of missile to clone
    public Transform launchPath;                // Launch path.
    public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
    public AudioClip m_FireClip;                // Audio that plays when each shot is fired.
    public Transform target;

    public Transform spawnPoint;

    [Tooltip("Set a control point to define the Bezier curve")]
    public Transform controlPoint;
    public Transform tempTargetPoint;

    String m_MissileButton;
    bool m_MissileLaunched;
    HomingMissile MyHomingMissile;

    void Start()
    {
        // The fire missile axis is based on the player number.
        m_MissileButton = "Missile" + m_PlayerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.gameObject.activeInHierarchy && Input.GetButtonUp(m_MissileButton) && !m_MissileLaunched)
        {
            // ... launch the shell.
            FireMissile();
        }
    }

    void FireMissile()
    {
        // Set the missile launched flag so only called once.
        m_MissileLaunched = true;

        // Relocate launch path set to Tank's position
        launchPath.position = transform.position;
        launchPath.rotation = transform.rotation;

        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody missileInstance = Instantiate(m_Missile) as Rigidbody;
        MyHomingMissile = missileInstance.GetComponent<HomingMissile>();
        MyHomingMissile.InitReference(spawnPoint, controlPoint, tempTargetPoint, target);

        // Change the clip to the firing clip and play it.
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();
        StartCoroutine(ReEnableMissile());
    }

    IEnumerator ReEnableMissile()
    {
        yield return new WaitForSeconds(5f);
        m_MissileLaunched = false;
    }
}
