using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class Wave : MonoBehaviour {
        public List<EnemyShip> Enemies;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Clear()
        {
            foreach (EnemyShip ES in Enemies)
                if (ES)
                    ES.TakeDamage(ES.MaxLife);
        }

        public bool MainCheck()
        {
            foreach (EnemyShip ES in Enemies)
                if (ES)
                    return false;
            Destroy(gameObject, 5);
            return true;
        }
    }
}