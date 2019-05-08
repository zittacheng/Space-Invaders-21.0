using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class Cutscene : MonoBehaviour {
        public Animator Anim;
        public bool Animating;
        public bool End;
        public bool AlreadyEnded;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Animating)
                return;

            if (Input.anyKeyDown)
                Anim.SetTrigger("Next");
            if (End && !AlreadyEnded)
            {
                AlreadyEnded = true;
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("SampleScene");
            }
        }
    }
}