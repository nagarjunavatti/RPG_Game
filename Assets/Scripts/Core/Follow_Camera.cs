using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class Follow_Camera : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] Transform myplayer;
        void Start()
        {
            
        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = myplayer.position;
        }
    }

}