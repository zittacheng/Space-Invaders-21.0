using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class SpaceInvaderControl : MonoBehaviour {
        [HideInInspector]
        public static SpaceInvaderControl Main;
        public CombatControl CC;
        public WaveControl WC;
        public MC MainCharacter;
        public Animator SceneFadeAnim;
        public Animator VictoryAnim;

        public void Awake()
        {
            Main = this;
            if (CC)
                CombatControl.Main = CC;
            if (WC)
                WaveControl.Main = WC;
            if (MainCharacter)
                MC.Main = MainCharacter;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
                Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }

        public void ChangeTransformDirection(Transform T, Vector3 Direction)
        {
            if (Direction.normalized.x == -1 && Direction.normalized.y == 0)
            {
                T.eulerAngles = new Vector3(0, 0, 180);
            }
            else
            {
                T.up = Direction;
                if (Mathf.Abs(T.transform.eulerAngles.z) > 0.1f)
                    T.eulerAngles = new Vector3(0, 0, T.eulerAngles.z);
                if (Mathf.Abs(180 - T.eulerAngles.y) <= 0.01f || Mathf.Abs(-180 - T.eulerAngles.y) <= 0.01f)
                    T.eulerAngles = new Vector3(0, 0, 180);
                if (Mathf.Abs(90 - T.eulerAngles.y) <= 0.01f || Mathf.Abs(-90 - T.eulerAngles.y) <= 0.01f)
                    T.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        public void Retry()
        {
            StartCoroutine("RetryIE");
        }

        public IEnumerator RetryIE()
        {
            SceneFadeAnim.SetBool("Play", true);
            yield return new WaitForSeconds(0.5f);
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("SampleScene");
        }

        public void Victory()
        {
            StartCoroutine("VictoryIE");
        }

        public IEnumerator VictoryIE()
        {
            VictoryAnim.SetBool("Play", true);
            yield return new WaitForSeconds(3.5f);
            SceneFadeAnim.SetBool("Play", true);
            yield return new WaitForSeconds(0.5f);
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Menu");
        }
    }
}