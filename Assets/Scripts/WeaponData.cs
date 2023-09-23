using UnityEngine;

public abstract class WeaponData : ScriptableObject
{
    [SerializeField] protected Weapon weaponPrefab;
    [SerializeField] private WeaponModel weaponModel;
    [SerializeField] private string weaponName;

    public Weapon WeaponPrefab => weaponPrefab;
    public WeaponModel WeaponModel => weaponModel;
    public string WeaponName => weaponName;
}