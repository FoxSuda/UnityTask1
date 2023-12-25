using UnityEngine;
using UnityEngine.UI;

public class PlayerCoinsDisplay : MonoBehaviour
{
    [SerializeField] private Text coinsText;

    public void DisplayCoins(int coinsCount)
    {
        coinsText.text = "Coins: " + coinsCount;
    }
}
