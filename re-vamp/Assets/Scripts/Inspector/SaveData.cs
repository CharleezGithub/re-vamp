using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WeaponDataCollection))]
class SaveData : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Test")) 
        {

            Debug.Log("Works");
        }
    }
}
