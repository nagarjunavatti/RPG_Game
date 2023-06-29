using UnityEngine;


namespace RPG.Combat
{
    public class EnemyHealth : MonoBehaviour 
    {
        [SerializeField] float health = 100f;
        bool isDead = false;
        public bool IsDead()
        {
            return isDead;
        }
        public void TakeDamage(float damageValue)
        {
            health = Mathf.Max(health - damageValue, 0);
            if(health == 0)
            {
                Death();
            }
        }

        void Death()
        {
            if(isDead)return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }
}
