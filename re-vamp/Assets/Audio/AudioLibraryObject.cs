using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "New AudioLibrary", menuName = "ZUtility/AudioLibrary")]
public class AudioLibraryObject : ScriptableObject
{
    public AudioClip[] Clips;
}
