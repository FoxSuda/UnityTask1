using Task1.Player;
using Task1.PlayerUI;
using Task1.Pool;
using UnityEngine;

public class PlayerUIInstantiate : MonoBehaviour
{

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Transform playerTransform;
    
    [SerializeField] private DamageUIObjectPool damageUIObjectPool;

    public void OnObjectHit(Transform damagePoint, float damage)
    {
        GameObject currentWeapon = playerStats.GetCurrentWeapon();
        PlayerWeaponBase shootWeapon = currentWeapon.GetComponent<PlayerWeaponBase>(); 
        var pooledDamageUi = damageUIObjectPool.Pool.Get();
        if (pooledDamageUi != null)
        {
            pooledDamageUi.transform.position = damagePoint.position;
            pooledDamageUi.transform.LookAt(playerTransform.position);
            pooledDamageUi.Initialize(damage, ReleaseBullet, playerTransform);
        }
    }

    private void ReleaseBullet(PlayerDamageUI DamageUI)
    {
        damageUIObjectPool.Pool.Release(DamageUI);
    }
}
