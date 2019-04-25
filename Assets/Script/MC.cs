﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class MC : MonoBehaviour {
        public Rigidbody2D Rig;
        public float Speed;
        [Space]
        public GameObject FirePoint;
        public float FireCoolRate;
        public float FireCoolDown;
        [Space]
        public GameObject BulletPrefab;

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
            if (Input.GetButton("Fire") && FireCoolDown <= 0)
                Fire();
        }

        public void Fire()
        {
            GameObject G = Instantiate(BulletPrefab);
            G.transform.position = FirePoint.transform.position;
            FireCoolDown = FireCoolRate;
        }
    }
}