using Task1.Player;
using UnityEngine;
using UnityEngine.UI;

public class HealthCount : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private PlayerStats playerHealth;

    void Update()
    {
        healthText.text = "" + playerHealth.GetHealthLevel();
    }
}
