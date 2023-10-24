using Task1.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Task1.Score
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private PlayerStats playerScore;

        public void AddScore()
        {
            scoreText.text = "" + playerScore.GetScore();
        }
    }
}

