using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Effects
{
    public class EntityFX : MonoBehaviour
    {
        protected SpriteRenderer sr;

        [Header("Flash FX")]
        [SerializeField] private float flashDuration;
        [SerializeField] private Material hitMat;
        private Material originalMat;

        protected virtual void Start()
        {
            sr = GetComponentInChildren<SpriteRenderer>();
            originalMat = sr.material;
        }

        private IEnumerator FlashFX()
        {
            sr.material = hitMat;
            Color currentColor = sr.color;
            sr.color = Color.white;

            yield return new WaitForSeconds(flashDuration);

            sr.color = currentColor;
            sr.material = originalMat;
        }

        private void RedColorBlink()
        {
            if (sr.color != Color.white)
                sr.color = Color.white;
            else
                sr.color = Color.red;
        }

        private void CancelColorChange()
        {
            CancelInvoke();
            sr.color = Color.white;
        }

    }
}
