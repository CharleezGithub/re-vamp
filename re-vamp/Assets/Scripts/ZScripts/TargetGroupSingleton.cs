using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGroupSingleton : MonoBehaviour
{
    public static TargetGroupSingleton Instance;

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
            Instance = this;
        }
    }
}
