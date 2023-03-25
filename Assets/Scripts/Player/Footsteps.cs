using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    //L8 Variables
    [SerializeField] private AudioClip[] footstepSFX;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private float playRate;
    private float lastPlayTime;

    void Update()
    {
        //L8 - play a sound if the player is moving AND enough time has passed since the last footstep
        if(rig.velocity.magnitude > 0 && Time.time - lastPlayTime > playRate)
        {
            Play();
        }
    }


    //L8 Create a play method - Records the last time the sound was played, then plays a random footstep sound
    void Play()
    {
        lastPlayTime = Time.time;
        AudioClip clipToPlay = footstepSFX[Random.Range(0,footstepSFX.Length)];
        audioSource.PlayOneShot(clipToPlay);
    }
}
