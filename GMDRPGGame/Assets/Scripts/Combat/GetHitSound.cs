using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitSound : MonoBehaviour
{
    public static AudioClip playerHitSound, enemyHitSound;
    static AudioSource audioSrc;
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        enemyHitSound = Resources.Load<AudioClip>("enemyHit");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "enemyHit":
                audioSrc.PlayOneShot(enemyHitSound);
                break;
        }
    }
}
