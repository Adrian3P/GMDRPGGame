using UnityEngine;
using RPG.Movement;
using System;
using RPG.Combat;
using RPG.Core;
using TMPro;
using UnityEngine.UI;
using RPG.Items;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        // Field to make faster turns of the camera
        [SerializeField]
        private float movingCameraSpeed = 2f;

        Health health;
        GameObject mainCamera;

        private GameObject targetHUD;
        private Slider hudTargetHealth;
        private TextMeshProUGUI hudTargetName;
        private bool bIsAttacking = false;

        private GameObject enemyTarget;

        private GameObject deathScreenObject;

        private InventorySystem inventory;
        [SerializeField] private UI_Inventory uiInventory;

        public void Awake()
        {
            health = GetComponent<Health>();
            if (mainCamera == null)
            {
                mainCamera = GameObject.FindGameObjectWithTag("FollowCamera");
            }

            if (targetHUD == null){
                targetHUD = GameObject.FindGameObjectWithTag("TargetHUD");
            }
            if (hudTargetHealth == null){
                hudTargetHealth = GameObject.FindGameObjectWithTag("HUDTargetHealth").GetComponent<Slider>();
            }

            if (hudTargetName == null){
                hudTargetName = GameObject.FindGameObjectWithTag("HUDTargetName").GetComponent<TextMeshProUGUI>();
            }
            if (deathScreenObject == null){
                deathScreenObject = GameObject.FindGameObjectWithTag("DeathScreenObject");
            }
            targetHUD.SetActive(false);
            deathScreenObject.SetActive(false);
            inventory = new InventorySystem();
            uiInventory.SetInventory(inventory);
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

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                targetHUD.gameObject.SetActive(false);
            }

            updateHUD();
            if (health.IsDead()){
                deathScreenObject.SetActive(true);
                return;
            }
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
                    enemyTarget = target.gameObject;
                    hudTargetName.text = target.transform.name;
                    if (hit.transform.gameObject.GetComponent<Health>() != null && !bIsAttacking)
                    {
                        hudTargetHealth.maxValue = target.transform.gameObject.GetComponent<Health>().getHealthPoints();
                        bIsAttacking = true;
                    }
                    targetHUD.SetActive(true);
                }
                return true;
            }
            return false;
        }

        private void updateHUD(){
            if (bIsAttacking && enemyTarget != null && enemyTarget.GetComponent<Health>() != null)
            {
                if (enemyTarget.GetComponent<Health>().getHealthPoints() <= 0)
                {
                    targetHUD.SetActive(false);
                }
                if (enemyTarget.GetComponent<Health>().IsDead())
                {
                    bIsAttacking = false;
                }
                hudTargetHealth.value = enemyTarget.GetComponent<Health>().getHealthPoints();
                hudTargetHealth.gameObject.SetActive(true);
            }
        }
        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    targetHUD.SetActive(true);
                    enemyTarget = hit.transform.gameObject;
                    hudTargetName.text = hit.transform.name;
                    hudTargetHealth.gameObject.SetActive(false);
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

        public InventorySystem GetInventorySystem()
        {
            return inventory;
        }

        public UI_Inventory GetUI_Inventory()
        {
            return uiInventory;
        }
    }
}


