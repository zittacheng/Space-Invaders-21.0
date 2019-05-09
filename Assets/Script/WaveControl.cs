using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class WaveControl : MonoBehaviour {
        [HideInInspector]
        public static WaveControl Main;
        public Wave CurrentWave;
        public List<Wave> Waves;
        public List<Wave> EndWaves;
        public int WaveCount;
        public bool Processing;

        // Start is called before the first frame update
        void Start()
        {
            NextWave();
        }

        // Update is called once per frame
        void Update()
        {
            if (CurrentWave && CurrentWave.MainCheck() && !Processing)
            {
                Processing = true;
                NextWave();
            }
        }

        public void NextWave()
        {
            StartCoroutine("NextWaveIE");
        }

        public IEnumerator NextWaveIE()
        {
            yield return new WaitForSeconds(0.5f);
            if (WaveCount < Waves.Count)
            {
                GameObject G = Instantiate(GetWave().gameObject);
                G.transform.position = CombatControl.Main.SpawnPosition.transform.position;
                G.SetActive(true);
                CurrentWave = G.GetComponent<Wave>();
                WaveCount++;
                Processing = false;
            }
            else
                SpaceInvaderControl.Main.Victory();
        }

        public void Retry()
        {
            WaveCount = 0;
            if (CurrentWave)
                CurrentWave.Clear();
        }

        public Wave GetWave()
        {
            if (WaveCount < Waves.Count)
                return Waves[WaveCount];
            else
                return EndWaves[Random.Range(0, EndWaves.Count)];
        }
    }
}