using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class Button : MonoBehaviour {
        public SpriteRenderer SR;
        public Sprite NormalSprite;
        public Sprite SelectingSprite;
        public string Key;
        public Animator FadeOut;
        [HideInInspector]
        public bool AlreadyEffected;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnMouseEnter()
        {
            SR.sprite = SelectingSprite;
        }

        public void OnMouseExit()
        {
            SR.sprite = NormalSprite;
        }

        public void OnMouseDown()
        {
            if (AlreadyEffected)
                return;

            AlreadyEffected = true;
            if (Key == "Start")
                StartCoroutine("StartEffectIE");
            else if (Key == "Exit")
                Application.Quit();
        }

        public IEnumerator StartEffectIE()
        {
            FadeOut.SetBool("Play", true);
            yield return new WaitForSeconds(0.5f);
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Cutscene");
        }
    }
}