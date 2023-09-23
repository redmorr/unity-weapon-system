using UnityEngine;

public class Firearm : MonoBehaviour, IAttacking
{
    private Weapon weapon;
    private FirearmData firearmData;

    public void Attack()
    {
        Debug.LogFormat("{0} -> Firearm attack!", firearmData.WeaponName);
    }

    public void Setup(Weapon weapon, WeaponData weaponData)
    {
        this.weapon = weapon;
        firearmData = (FirearmData)weaponData;
    }
}