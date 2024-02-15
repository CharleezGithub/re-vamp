using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPController : LevelController
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("XPOrb"))
        {
            Destroy(other.gameObject);
            GiveXP(1);
        }
    }
}
