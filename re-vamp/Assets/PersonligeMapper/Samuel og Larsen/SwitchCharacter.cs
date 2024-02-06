using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    public int index = 0;
    public Texture2D gun;
    public void Switch() {
        index += 1;
        gun = weapon_class[index];

   }
    public void Switchback()
    {
        index -= 1;
        gun = weapon_class[index];
    }