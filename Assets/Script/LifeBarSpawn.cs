using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class LifeBarSpawn : MonoBehaviour {
        public LifeBar LB;
        public EnemyShip ES;

        private void OnEnable()
        {
            LB.Ship = ES;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}