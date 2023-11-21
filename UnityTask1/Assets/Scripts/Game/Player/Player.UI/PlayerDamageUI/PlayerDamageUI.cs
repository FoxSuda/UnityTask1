using System;
using System.Collections;
using System.Collections.Generic;
using Task1.Player;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Task1.PlayerUI
{
    public class PlayerDamageUI : MonoBehaviour
    {
        private Transform playerTransformPosition;
        [SerializeField] private Text damageText;
        private Action<PlayerDamageUI> OnPlayerDamageUIReleased;
        public void Initialize(float damage, Action<PlayerDamageUI> onPlayerDamageUIReleased, Transform playerTransform)
        {
            playerTransformPosition = playerTransform;
            damageText.text = "" + damage;
            OnPlayerDamageUIReleased = onPlayerDamageUIReleased;
            StartCoroutine(MoveObjectAndInvoke());
        }

        private void Update()
        {
            Vector3 directionToPlayer = playerTransformPosition.position - gameObject.transform.position;
            Vector3 oppositeDirection = -directionToPlayer;
            oppositeDirection.Normalize();
            Quaternion lookRotation = Quaternion.LookRotation(oppositeDirection);
            gameObject.transform.rotation = lookRotation;
        }

        public void Dispose()
        {
            OnPlayerDamageUIReleased = null;
        }

        private IEnumerator MoveObjectAndInvoke()
        {
            float elapsedTime = 0f;
            float duration = 2f;

            Vector3 startPosition = transform.position;
            Vector3 targetPosition = startPosition + Vector3.up * 5f;

            while (elapsedTime < duration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(2f);

            OnPlayerDamageUIReleased?.Invoke(this);
        }

    }
}

