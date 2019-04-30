using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class CombatControl : MonoBehaviour {
        [HideInInspector]
        public static CombatControl Main;
        public GameObject SpawnPosition;
        public float LeftLimit;
        public float RightLimit;
        [Space]
        public bool Resetting;
        public GameObject MCPrefab;
        public GameObject MCSpawnPoint;

        public void Awake()
        {
            Ini();
        }

        public void Ini()
        {
            GameObject G = Instantiate(MCPrefab);
            G.transform.position = MCSpawnPoint.transform.position;
            MC.Main = G.GetComponent<MC>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Resetting && Input.GetButtonDown("Fire"))
                Retry();
        }

        public void Retry()
        {
            Resetting = false;
            Ini();
            WaveControl.Main.Retry();
        }

        public void Defeat()
        {
            Destroy(MC.Main.gameObject);
            StartCoroutine("DefeatIE");
        }

        public IEnumerator DefeatIE()
        {
            yield return new WaitForSeconds(1);
            Resetting = true;
        }
    }
}