using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class EnemyAnimationTriggers : MonoBehaviour
    {
        private Enemy enemy => GetComponentInParent<Enemy>();

        private void AnimationTrigger()
        {
            enemy.AnimationFinishTrigger();
        }
    }
}
