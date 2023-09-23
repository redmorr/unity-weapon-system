using UnityEngine;

public class Melee : MonoBehaviour, IAttacking
{
    private Weapon weapon;
    private MeleeData meleeData;

    public void Setup(Weapon weapon, WeaponData weaponData)
    {
        this.weapon = weapon;
        meleeData = (MeleeData)weaponData;
    }

    public void Attack()
    {
        Debug.LogFormat("{0} -> Melee attack!", meleeData.WeaponName);
    }
}