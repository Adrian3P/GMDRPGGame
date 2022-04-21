using UnityEngine;

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;

        [SerializeField] bool isDead;

        public void Start(){
            isDead = false;
        }
        private void Update()
        {
            if (healthPoints <= 0)
            {
                Die();
            }
        }

        public bool IsDead()
        {
            return isDead;
        }
        
        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
        }

        public float getHealthPoints(){
            return healthPoints;
        }

        private void Die()
        {
            if (!isDead){
                
                isDead = true;
                GetComponent<Animator>().SetTrigger("die");
                GetComponent<ActionScheduler>().CancelCurrentAction();
            }
        }
    }
}