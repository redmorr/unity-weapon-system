using TMPro;
using UnityEngine;

public class HUDWeapon : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponNameText;
    [SerializeField] private PlayerController playerController;
    
    private void OnEnable()
    {
        playerController.OnWeaponSwitched += UpdateName;
    }
    
    private void OnDisable()
    {
        playerController.OnWeaponSwitched -= UpdateName;
    }
    
    private void UpdateName(string weaponName)
    {
        weaponNameText.SetText(weaponName);
    }
}