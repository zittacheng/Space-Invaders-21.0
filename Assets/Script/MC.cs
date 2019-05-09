using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class MC : MonoBehaviour {
        [HideInInspector]
        public static MC Main;
        public Animator Anim;
        public Rigidbody2D Rig;
        public float Speed;
        [Space]
        public List<GameObject> FirePoints;
        public List<GameObject> BulletPrefabs;
        public float FireCoolRate;
        public float FireCoolDown;
        [Space]
        public bool Animating;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float h = 0;
            float v = 0;
            if (Input.GetButton("Right"))
                h = 1;
            else if (Input.GetButton("Left"))
                h = -1;
            else
                h = 0;
            if (Input.GetButton("Up"))
                v = 1;
            else if (Input.GetButton("Down"))
                v = -1;
            else
                v = 0;
            float a = h * Speed;
            float b = v * Speed;
            Rig.velocity = new Vector2(a, b);
            FireCoolDown -= Time.deltaTime;
            if (Input.GetButton("Fire") && FireCoolDown <= 0 && !Animating)
                Fire();
        }

        public void Fire()
        {
            FireCoolDown = FireCoolRate;
            for (int i = 0; i < FirePoints.Count; i++)
            {
                GameObject G = Instantiate(BulletPrefabs[i]);
                G.transform.eulerAngles = FirePoints[i].transform.eulerAngles;
                G.transform.position = FirePoints[i].transform.position;
            }
        }

        public void Death()
        {
            Anim.SetBool("Death", true);
            CombatControl.Main.Defeat();
            Destroy(gameObject, 5);
            Destroy(this);
        }
    }
}