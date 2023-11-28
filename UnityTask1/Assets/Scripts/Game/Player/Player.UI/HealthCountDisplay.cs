using Task1.Player;
using UnityEngine;
using UnityEngine.UI;

public class HealthCountDisplay : MonoBehaviour
{
    [SerializeField] private Text healthText;

    public void DisplayHealth(float health)
    {
        healthText.text = "" + health;
    }
}
