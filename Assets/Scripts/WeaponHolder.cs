using UnityEngine;

public class WeaponHolder : MonoBehaviour {
    public int selectedWeapon = 0;
    private int weaponCount;

    private void Start() {
        weaponCount = transform.childCount;
        SelectWeapon();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.P) && selectedWeapon < weaponCount - 1) {
            selectedWeapon++;
            SelectWeapon();
        }

        if (Input.GetKeyDown(KeyCode.L) && selectedWeapon > 0) {
            selectedWeapon--;
            SelectWeapon();
        }
    }

    private void SelectWeapon() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }

        transform.GetChild(selectedWeapon).gameObject.SetActive(true);
    }
}