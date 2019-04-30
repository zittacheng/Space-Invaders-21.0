using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SI
{
    public class EnemyShip : MonoBehaviour {
        public float MaxLife;
        public float Life;
        [Space]
        public Rigidbody2D Rig;
        public float Speed;
        public float SpeedScale;
        public float SpeedScaleChange;
        public float MinChangeTime;
        public float MaxChangeTime;
        [Space]
        public bool Starting;
        public float StartDistance;
        public float StartSpeed;
        public float TargetPositionY;
        [Space]
        public GameObject TurretPoint;
        public List<GameObject> FirePoints;
        public List<GameObject> BulletPrefabs;
        [Space]
        public float FireCoolRate;
        public float FireCoolDown;
        public int FireTime = 1;
        public float FireTimeDelay;
        [Space]
        public bool AlradyDead;

        // Start is called before the first frame update
        void Start()
        {
            if (StartDistance >= 0)
            {
                Starting = true;
                TargetPositionY = transform.position.y - StartDistance;
            }
            StartCoroutine("SpeedProcess");
        }

        // Update is called once per frame
        void Update()
        {
            if (Starting)
            {
                if (transform.position.y > TargetPositionY)
                {
                    SetSpeed(0, -StartSpeed);
                    return;
                }
                else
                {
                    SetSpeed(0, 0);
                    Starting = false;
                }
            }

            if (CanFire())
            {
                if (FireCoolDown <= 0)
                    Fire();
                else
                    FireCoolDown -= Time.deltaTime;
            }

            UpdateSpeed();
            if (MC.Main)
                SpaceInvaderControl.Main.ChangeTransformDirection(TurretPoint.transform, MC.Main.transform.position - TurretPoint.transform.position);

            if (Life <= 0)
                Death();
        }

        public void UpdateSpeed()
        {
            SetSpeed(Speed * SpeedScale, 0);
        }

        public IEnumerator SpeedProcess()
        {
            while (Starting)
                yield return 0;
            if (Random.Range(-0.99f, 0.99f) > 0)
            {
                while (true)
                {
                    yield return ToLeftProcess();
                    yield return FixWait(Random.Range(MinChangeTime, MaxChangeTime));
                    yield return ToRightProcess();
                    yield return FixWait(Random.Range(MinChangeTime, MaxChangeTime));
                    yield return 0;
                }
            }
            else
            {
                while (true)
                {
                    yield return ToRightProcess();
                    yield return FixWait(Random.Range(MinChangeTime, MaxChangeTime));
                    yield return ToLeftProcess();
                    yield return FixWait(Random.Range(MinChangeTime, MaxChangeTime));
                    yield return 0;
                }
            }
        }

        public IEnumerator ToLeftProcess()
        {
            while (SpeedScale > -1)
            {
                SpeedScale -= SpeedScaleChange * Time.deltaTime;
                yield return 0;
            }
            SpeedScale = -1;
        }

        public IEnumerator ToRightProcess()
        {
            while (SpeedScale < 1)
            {
                SpeedScale += SpeedScaleChange * Time.deltaTime;
                yield return 0;
            }
            SpeedScale = 1;
        }

        public IEnumerator FixWait(float Value)
        {
            float a = 0;
            while (a < Value && !LimitCheck())
            {
                a += Time.deltaTime;
                yield return 0;
            }
        }

        public void SetSpeed(float X, float Y)
        {
            SetSpeed(new Vector2(X, Y));
        }

        public void SetSpeed(Vector2 Value)
        {
            Rig.velocity = Value;
        }

        public void Fire()
        {
            FireCoolDown = FireCoolRate;
            StartCoroutine("FireIE");
        }

        public IEnumerator FireIE()
        {
            for (int i = 0; i < FireTime; i++)
            {
                for (int j = FirePoints.Count - 1; j >= 0; j--)
                {
                    GameObject G = Instantiate(BulletPrefabs[j]);
                    G.transform.position = FirePoints[j].transform.position;
                    G.transform.eulerAngles = FirePoints[j].transform.eulerAngles;
                    G.SetActive(true);
                }
                yield return new WaitForSeconds(FireTimeDelay);
            }
            yield return 0;
        }

        public void TakeDamage(float Damage)
        {
            Life -= Damage;
        }

        public void Death()
        {
            AlradyDead = true;
            Destroy(gameObject);
        }

        public bool LimitCheck()
        {
            return (transform.position.x >= CombatControl.Main.RightLimit && SpeedScale > 0) || (transform.position.x <= CombatControl.Main.LeftLimit && SpeedScale < 0);
        }

        public bool CanFire()
        {
            return !AlradyDead && !Starting && MC.Main;
        }
    }
}