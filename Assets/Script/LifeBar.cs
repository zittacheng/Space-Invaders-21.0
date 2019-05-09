using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class LifeBar : MonoBehaviour {
        public EnemyShip Ship;
        public GameObject AnimBase;
        public GameObject Bar;
        public Vector2 PositionRange;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!Ship || !Ship.gameObject.activeSelf)
            {
                AnimBase.SetActive(false);
                return;
            }

            AnimBase.SetActive(true);
            float a = PositionRange.x + Ship.Life / Ship.MaxLife * (PositionRange.y - PositionRange.x);
            Bar.transform.localPosition = new Vector3(a, Bar.transform.localPosition.y, Bar.transform.localPosition.z);
        }
    }
}