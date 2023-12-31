using UnityEngine;

namespace RPG.Core
{

    public class Scheduler : MonoBehaviour
    {
        IAction currentAction;
        public void SwitchingAction(IAction action)
        {
            if(currentAction == action)return;
            if(currentAction != null)
            {
                currentAction.Cancel();
            }   
            currentAction = action; 
        }
    }
}
