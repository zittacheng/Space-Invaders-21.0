﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class Bullet : MonoBehaviour {
        public Rigidbody2D Rig;
        public float Speed;
        public float DestroyTime = 5;

        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, DestroyTime);
        }

        // Update is called once per frame
        void Update()
        {
            Rig.velocity = transform.TransformDirection(0, Speed, 0);
        }
    }
}