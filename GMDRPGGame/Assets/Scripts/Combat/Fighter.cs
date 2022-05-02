using UnityEngine;
using RPG.Movement;
using RPG.Core;
using RPG.Sounds;
using System;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] Transform handTransform = null;
        [SerializeField] Weapon defaultWeapon = null;

        Health target;
        float timeSinceLastAttack = Mathf.Infinity;
        Weapon currentWeapon = null;
        GameObject audioGameObject;

        private void Start()
        {
            audioGameObject = GameObject.FindGameObjectWithTag("audioGameObject");
            EquipWeapon(defaultWeapon);
        }

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if ( target != null && !target.IsDead() && !GetComponent<Health>().IsDead())
            {
                if (!GetIsInRange())
                {
                    GetComponent<Mover>().MoveTo(target.transform.position);

                    if (GetIsInRange())
                    {
                        GetComponent<Mover>().Cancel();
                    }
                }
                else if (GetIsInRange())
                {
                    AttackBehaviour();
                }
            }

        }

        public void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            Animator animator = GetComponent<Animator>();
            weapon.Spawn(handTransform, animator);
        }

        private void AttackBehaviour()
        {

            transform.LookAt(target.transform);

            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                TriggerAttack();
                timeSinceLastAttack = 0;
            }
        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }


        //Animation Event
        void Hit()
        {
            if (target)
            {
                target.TakeDamage(currentWeapon.GetDamage());
                audioGameObject.GetComponent<SoundEffects>().PlaySound("swordAttack");
            }
            
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < currentWeapon.GetRange();
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null)
            {
                return false;
            }
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            StopAttack();
            GetComponent<ActionScheduler>().CancelCurrentAction();
            target = null;
        }

        public void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }

        public Weapon GetDefaultWeapon()
        {
            return defaultWeapon;
        }

        public GameObject GetCurrentWeapon(){
            return currentWeapon.GetequippedPrefab();
        }
    }
}