using System.Threading.Tasks;
using UnityEngine;
using RPG.Sounds;

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;

        [SerializeField] bool isDead;

        GameObject audioGameObject;
        private float maxHealth { get; set; }

        public void Start(){
            isDead = false;
            maxHealth = healthPoints;
            audioGameObject = GameObject.FindGameObjectWithTag("audioGameObject");
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
            audioGameObject.GetComponent<SoundEffects>().PlaySound("enemyHit");
        }

        public float GetHealthPoints(){
            return healthPoints;
        }

        public float GetMaxHealthPoints()
        {
            return maxHealth;
        }

        private void Die()
        {
            if (!isDead){
                
                isDead = true;
                GetComponent<Animator>().SetTrigger("die");
                GetComponent<ActionScheduler>().CancelCurrentAction();
                audioGameObject.GetComponent<SoundEffects>().PlaySound("diedSound");
            }
        }

        public async void Heal(float heal)
        {
            //check if after healing healthPoints will not be greater than maxHealth
            if ((healthPoints + heal) > maxHealth)
            {
                heal = maxHealth - healthPoints;
            }
            //heal over time (5 hp per sec)
            for (float x = 0; x < heal; x += 5)
            {
                healthPoints += 5;
                await Task.Delay(1000);
            }
            //insta heal
            //healthPoints = (healthPoints + heal) >= maxHealth ? maxHealth : healthPoints + heal;
        }
    }
}