using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInstantiater : MonoBehaviour
{
    [SerializeField] private GameObject trinkets;
    [SerializeField] private GameObject weapons;

    public void InstanstiateWeapon(GameObject weaponPrefab)
    {
        Instantiate(weaponPrefab, weapons.transform.position, Quaternion.identity);
    }
    public void InstanstiateTrinket(GameObject trinketPrefab)
    {
        Instantiate(trinketPrefab, trinkets.transform.position, Quaternion.identity);
    }
}
