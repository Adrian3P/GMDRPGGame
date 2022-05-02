using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;
using RPG.Sounds;


namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] Transform target;
        NavMeshAgent navMeshAgent;
        Health health;
        GameObject audioGameObject;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
            audioGameObject = GameObject.FindGameObjectWithTag("audioGameObject");
        }


        public void Update()
        {
            navMeshAgent.enabled = !health.IsDead();

            UpdateAnimator();
        }
        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            if (navMeshAgent.enabled)
            {
                navMeshAgent.destination = destination;
                navMeshAgent.isStopped = false;
            }
        }

        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }


        void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}
