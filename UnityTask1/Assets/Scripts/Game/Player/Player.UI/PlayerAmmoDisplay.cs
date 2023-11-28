using UnityEngine;
using UnityEngine.UI;

public class PlayerAmmoDisplay : MonoBehaviour
{
    [SerializeField] private Text weaponAmmoText;

    public void DisplayAmmo(int currentAmmo, int maxAmmo)
    {
        weaponAmmoText.text = "" + currentAmmo + "/" + maxAmmo;
    }
}
