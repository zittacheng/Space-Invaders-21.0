using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class LifeRenderer : MonoBehaviour {
        public List<SpriteRenderer> SRs;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Render(CombatControl.Main.Life);
        }

        public void Render(int Value)
        {
            for (int i = SRs.Count - 1; i >= 0; i--)
            {
                if (i < Value)
                    SRs[i].enabled = true;
                else
                    SRs[i].enabled = false;
            }
        }
    }
}