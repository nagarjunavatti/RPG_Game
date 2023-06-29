using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange =2f;         //distance between player and enemy
        [SerializeField] float weaponDamage =5f;
        [SerializeField] float timeBetweenAttacks;    //for delaying or speeding attacks
        Transform target;
        float timeElapsed = 0;
        private void Update()
        {   
            timeElapsed += Time.deltaTime;
            if(target == null)return;
            if(target.GetComponent<EnemyHealth>().IsDead())return;

            if (!isInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
                if(timeElapsed>timeBetweenAttacks)
                {
                    Punch();
                    timeElapsed =0;
                }
            }

            bool isInRange()
            {
                return Vector3.Distance(transform.position, target.position) < weaponRange;
            }
        }
        public void Attack(CombatTarget enemy)
        {
            GetComponent<Scheduler>().SwitchingAction(this);
            target = enemy.transform;
        }
        public void Cancel()
        {
            
            target = null;
        }

        //Animation Events
        void Punch()
        {
            GetComponent<Animator>().SetTrigger("punch");
        }

        void Hit()   //Default event that came with punch animation. Creates event at the time of punch hit
        {
            EnemyHealth health = target.GetComponent<EnemyHealth>();
            health.TakeDamage(weaponDamage);
        }
    }
}
