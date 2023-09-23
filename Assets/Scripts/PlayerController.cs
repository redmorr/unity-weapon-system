using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum KeyPressState
    {
        Down,
        Held,
        Up
    }

    [SerializeField] private Transform weaponSocket;
    [SerializeField] private WeaponData[] weaponData;

    public event Action<string> OnWeaponSwitched;

    private PlayerControls input;
    private Weapon[] weapons;
    private int index;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        input = new PlayerControls();
        InstantiateWeapons();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void InstantiateWeapons()
    {
        weapons = new Weapon[weaponData.Length];
        for (int i = 0; i < weaponData.Length; i++)
        {
            weapons[i] = Instantiate(weaponData[i].WeaponPrefab, weaponSocket);
            weapons[i].Setup(weaponData[i]);
        }

        foreach (Weapon weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        if (weapons[0] == null) return;
        index = 0;
        weapons[index].gameObject.SetActive(true);
        OnWeaponSwitched?.Invoke(weapons[index].WeaponData.WeaponName);
    }

    public void CycleWeapon()
    {
        if (index >= 0) weapons[index].gameObject.SetActive(false);
        index = (index + 1) % weapons.Length;
        weapons[index].gameObject.SetActive(true);
        OnWeaponSwitched?.Invoke(weapons[index].WeaponData.WeaponName);
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (input.Gameplay.Switch.WasPressedThisFrame()) CycleWeapon();

        if (input.Gameplay.Shoot.WasPressedThisFrame())
        {
            HandleUse(KeyPressState.Down);
            return;
        }

        if (input.Gameplay.Shoot.IsPressed())
        {
            HandleUse(KeyPressState.Held);
            return;
        }

        if (input.Gameplay.Shoot.WasReleasedThisFrame())
        {
            HandleUse(KeyPressState.Up);
        }
    }

    public void HandleUse(KeyPressState keyPressState)
    {
        weapons[index].HandleButtonPress(keyPressState);
    }

    private void OnDisable()
    {
        input.Disable();
    }
}