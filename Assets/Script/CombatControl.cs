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
        public GameObject MCPrefab;
        public GameObject MCSpawnPoint;
        public int Life;

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

        }

        public void Retry()
        {
            if (Life > 0)
            {
                Life--;
                Ini();
            }
            else
                SpaceInvaderControl.Main.Retry();
        }

        public void Defeat()
        {
            StartCoroutine("DefeatIE");
        }

        public IEnumerator DefeatIE()
        {
            yield return new WaitForSeconds(1);
            Retry();
        }
    }
}