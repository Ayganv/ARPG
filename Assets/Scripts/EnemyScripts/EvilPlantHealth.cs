﻿using Player;
using Units;
using UnityEngine;
using System.Collections;

namespace EnemyScripts
{
    public class EvilPlantHealth : UnitHealth
    {
        public ParticleSystem hitEffect1;
        public ParticleSystem hitEffect2;
        public float DestroyDelay = 3.0f;

        private void FixedUpdate()
        {
            if (Health <= 0)
            {
                PlayerManager.Instance.RangedAttack.hasATarget = false;
                StartCoroutine(WaitAndDestroy(DestroyDelay));
            }
        }

        private IEnumerator WaitAndDestroy(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            Destroy(gameObject);
        }

        public void OnHitVFX()
        {
            hitEffect1.Play();
            hitEffect2.Play();
        }
    }
}