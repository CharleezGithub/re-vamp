using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR

[CustomEditor(typeof(DataCollection))]
class SaveDataCollection : Editor
{
    public DataCollection data;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Load Items")) 
        {
            data.AddWeaponData();

            data.AddTrinketData();

            Debug.Log("Weapons and Trinket Saved");
        }
    }
}

#endif