using UnityEngine;

[CreateAssetMenu(menuName = "Game/Configs/Weapon configuration", fileName = "Weapon configuration")]
public class WeaponConfiguration : ScriptableObject
{
    [SerializeField] private float damage = 15;
    [SerializeField] private int maxAmmo = 30;
    [SerializeField] private float reloadTime = 2.0f;

    public float Damage { get => damage; set => damage = value; }
    public int MaxAmmo { get => maxAmmo; set => maxAmmo = value; }
    public float ReloadTime { get => reloadTime; set => reloadTime = value; }
}
