using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using System;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(InteractWithCombat())return;
            if(InteractWithMovement())return;
            print("Nothing to do");           //displays if you click beyond the map
        }
        bool InteractWithMovement()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit_obj;
            if(Physics.Raycast(ray, out Hit_obj))
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(Hit_obj.point);
                }
                return true;   //if we hit/hover any object (ground, terrain, enemy, box)
            }
            return false;         //if no hit/hover is detected i.e clicking outside level range 
        }

        bool InteractWithCombat()
        {
            Ray hoverRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit checkEnemy;
            if(Physics.Raycast(hoverRay, out checkEnemy))
            {
                CombatTarget enemy = checkEnemy.transform.GetComponent<CombatTarget>();
                if(enemy == null)
                {
                    return false;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(enemy);
                }
            }
            return true;
        }
    }

}