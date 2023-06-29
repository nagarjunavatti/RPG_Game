using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        // Start is called before the first frame update
        NavMeshAgent playerAgent;
        void Start()
        {
            playerAgent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();
        }
        
        public void StartMoveAction(Vector3 endDestination)
        {
            GetComponent<Scheduler>().SwitchingAction(this);   //Cancelling Fighter action
            MoveTo(endDestination);
        }
        
        public void MoveTo(Vector3 endPosition)
        {
            playerAgent.destination = endPosition;
            playerAgent.isStopped = false;
        }

        public void Stop()
        {
            playerAgent.isStopped = true;
        }
        void UpdateAnimator()
        {
            Vector3 velocity = playerAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;

            GetComponent<Animator>().SetFloat("PlayerSpeed",speed);
        }
        public void Cancel()
        {
            
        }
    }

}