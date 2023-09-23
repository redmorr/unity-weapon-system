using UnityEngine;

[CreateAssetMenu(fileName = "melee_", menuName = "Weapon Data/Melee Data", order = 1)]
public class MeleeData : WeaponData
{
    private enum MeleeType
    {
        Knife,
        Sword
    }

    [SerializeField] private MeleeType type;
    
    private void OnValidate()
    {
        if (weaponPrefab != null && !weaponPrefab.TryGetComponent(typeof(Melee), out _))
        {
            Debug.LogErrorFormat("{0} - Implementation type in prefab does not match its data type!", name);
        }
    }
}