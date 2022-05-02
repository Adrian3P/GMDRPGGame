using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Sounds
{
    public class SoundEffects : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> playerHitSound;
        [SerializeField] private List<AudioClip> enemyHitSound;
        [SerializeField] private List<AudioClip> swordAttack;
        [SerializeField] private List<AudioClip> diedSound;

        private AudioSource audioSrc;
        void Start()
        {
            audioSrc = GetComponent<AudioSource>();
        }

        public void PlaySound(string clip)
        {
            switch (clip)
            {
                case "playerHit":
                    audioSrc.PlayOneShot(playerHitSound[Random.Range(0, playerHitSound.Count)], 0.5f);
                    break;
                case "enemyHit":
                    audioSrc.PlayOneShot(enemyHitSound[Random.Range(0, enemyHitSound.Count)], 0.5f);
                    break;
                case "swordAttack":
                    audioSrc.PlayOneShot(swordAttack[Random.Range(0, swordAttack.Count)], 0.5f); 
                    break;
                case "diedSound":
                    audioSrc.PlayOneShot(diedSound[Random.Range(0, diedSound.Count)], 0.5f);
                    break;
            }
        }
    }
}
