using UnityEngine;
using RPG.Movement;
using System;
using RPG.Combat;
using RPG.Core;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        // Field to make faster turns of the camera
        [SerializeField]
        private float movingCameraSpeed = 2f;

        Health health;
        GameObject mainCamera;

        private void Start()
        {
            health = GetComponent<Health>();
            if(mainCamera == null)
            {
                mainCamera = GameObject.FindGameObjectWithTag("FollowCamera");
            }
        }

        private void Update()
        {
            // While holidng mouse button 2 , you can move your Y axis
            if(Input.GetMouseButton(1)){
                mainCamera.transform.eulerAngles += movingCameraSpeed *  new Vector3(0, Input.GetAxis("Mouse X"), 0);
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (mainCamera.GetComponentInChildren<Camera>().fieldOfView> 1)
                {
                    mainCamera.GetComponentInChildren<Camera>().fieldOfView--;
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (mainCamera.GetComponentInChildren<Camera>().fieldOfView < 100)
                {
                    mainCamera.GetComponentInChildren<Camera>().fieldOfView++;
                }
            }

            if (health.IsDead()) return;
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) 
                    continue;

                if (!GetComponent<Fighter>().CanAttack(target.gameObject))
                {
                    continue;
                }
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Fighter>().Attack(target.gameObject);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().MoveTo(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

    }
}


