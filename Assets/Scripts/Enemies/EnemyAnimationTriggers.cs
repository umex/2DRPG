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

        private void AttackTrigger()
        {
            // we will get all colliders but only interact with specific inside of our attackCheck gizmo 
            Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);
            foreach (var hit in colliders)
            {
                if (hit.GetComponent<Player>() != null)
                {
                    hit.GetComponent<Player>().Damage();
                }
            }
        }

        private void OpenCounterWindow() => enemy.OpenCounterAttackWindow();
        private void CloseCounterWindow() => enemy.CloseCounterAttackWindow();
    }
}
