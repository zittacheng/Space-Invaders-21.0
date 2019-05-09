using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class SoundtrackLoop : MonoBehaviour {
        [HideInInspector]
        public static SoundtrackLoop Main;
        public AudioSource Source0;
        public AudioSource Source1;
        public bool MinSource;
        public float LoopTime;

        public void Awake()
        {
            if (Main)
                Destroy(this);
            else
            {
                Main = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine("ProcessIE");
        }

        // Update is called once per frame
        void Update()
        {

        }

        public IEnumerator ProcessIE()
        {
            Source0.Play();
            while (true)
            {
                yield return new WaitForSecondsRealtime(LoopTime);
                if (MinSource)
                {
                    Source0.Play();
                    MinSource = false;
                }
                else
                {
                    Source1.Play();
                    MinSource = true;
                }
            }
        }
    }
}