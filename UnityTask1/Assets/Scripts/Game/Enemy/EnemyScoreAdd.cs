using System.Collections;
using System.Collections.Generic;
using Task1.UI;
using UnityEngine;

namespace Task1.Score
{
    public class EnemyScoreAdd : MonoBehaviour
    {
        private PlayerScore score;

        public void SetScore(PlayerScore score)
        {
            this.score = score;
        }

        private void OnDestroy()
        {
            if (score != null)
            {
                score.AddScore();
            }
        }
    }
}

