using UnityEngine;

[RequireComponent(typeof(IAttacking))]
public class Weapon : MonoBehaviour
{
    public WeaponData WeaponData => weaponData;

    private WeaponData weaponData;
    private WeaponModel weaponModel;
    private IAttacking attacking;

    public void Setup(WeaponData weaponData)
    {
        this.weaponData = weaponData;
        name = this.weaponData.WeaponName;
        attacking = GetComponent<IAttacking>();
        attacking.Setup(this, weaponData);
        weaponModel = Instantiate(weaponData.WeaponModel, transform);
    }

    public void HandleButtonPress(PlayerController.KeyPressState keyPressState)
    {
        if (keyPressState == PlayerController.KeyPressState.Down)
        {
            attacking.Attack();
        }
    }
}