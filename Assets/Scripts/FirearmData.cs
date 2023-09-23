using UnityEngine;

[CreateAssetMenu(fileName = "firearm_", menuName = "Weapon Data/Firearm Data", order = 1)]
public class FirearmData : WeaponData
{
    private enum FirearmType
    {
        Pistol,
        Shotgun,
        SubmachineGun
    }
    
    [SerializeField] private FirearmType type;
    [SerializeField] private int ammo;

    private void OnValidate()
    {
        if (weaponPrefab != null && !weaponPrefab.TryGetComponent(typeof(Firearm), out _))
        {
            Debug.LogErrorFormat("{0} - Implementation type in prefab does not match its data type!", name);
        }
    }
}