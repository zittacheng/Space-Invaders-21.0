using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class Weapon : MonoBehaviour {
        public bool Active;
        [Space]
        public GameObject TurretPoint;
        public List<GameObject> FirePoints;
        public List<GameObject> BulletPrefabs;
        [Space]
        public float FireCoolRate;
        public float FireCoolDown;
        public int FireTime = 1;
        public float FireTimeDelay;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (CanFire())
            {
                if (FireCoolDown <= 0)
                    Fire();
                else
                    FireCoolDown -= Time.deltaTime;
            }

            if (MC.Main)
                SpaceInvaderControl.Main.ChangeTransformDirection(TurretPoint.transform, MC.Main.transform.position - TurretPoint.transform.position);
        }

        public void SetState(bool Value)
        {
            Active = Value;
        }

        public void Fire()
        {
            FireCoolDown = FireCoolRate;
            StartCoroutine("FireIE");
        }

        public IEnumerator FireIE()
        {
            for (int i = 0; i < FireTime; i++)
            {
                for (int j = FirePoints.Count - 1; j >= 0; j--)
                {
                    GameObject G = Instantiate(BulletPrefabs[j]);
                    G.transform.position = FirePoints[j].transform.position;
                    G.transform.eulerAngles = FirePoints[j].transform.eulerAngles;
                    G.SetActive(true);
                }
                yield return new WaitForSeconds(FireTimeDelay);
            }
            yield return 0;
        }

        public bool CanFire()
        {
            return Active && MC.Main;
        }
    }
}