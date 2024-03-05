using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiMissile : MonoBehaviour
{
    public Rigidbody m_Shell;
    public Transform m_FireTransform;           // The Turret - spawn position of our antimissile
    public float m_LaunchForce;
    public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
    public AudioClip m_FireClip;                // Audio that plays when each shot is fired.

    float timer = 0f;
    public float timeLimit = 0.5f;
    bool fired = false;
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeLimit && fired)
        {
            fired = false;
        }
    }

    public void FireCWIS()
    {
        if (!fired)
        {
            // fire once at seconds interval
            fired = true;
            timer = 0;
            // Create an instance of the shell and store a reference to it's rigidbody.
            Rigidbody shellInstance =
            Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

            // Set the shell's velocity to the launch force in the fire position's forward direction.
            shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;

            // Change the clip to the firing clip and play it.
            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play();
        }
    }
}
