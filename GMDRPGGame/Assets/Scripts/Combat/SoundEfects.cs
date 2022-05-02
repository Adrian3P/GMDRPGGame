using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEfects : MonoBehaviour
{
    public static AudioClip playerHitSound, enemyHitSound, swordAttack;
    static AudioSource audioSrc;
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        enemyHitSound = Resources.Load<AudioClip>("enemyHit");
        swordAttack = Resources.Load<AudioClip>("swordAttack");

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
            //case "playerHit":
            //    audioSrc.PlayOneShot(playerHitSound);
            //    break;
            case "enemyHit":
                audioSrc.PlayOneShot(enemyHitSound);
                break;
            case "swordAttack":
                audioSrc.PlayOneShot(swordAttack);
                break;
        }
    }
}
