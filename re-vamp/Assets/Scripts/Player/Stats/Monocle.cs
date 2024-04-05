using Cinemachine;
using UnityEngine;

public class Monocle : MonoBehaviour
{
    public float fovMultiplier = 1.4f;

    private CinemachineTargetGroup targetGroupComp;

    private void OnEnable()
    {
        targetGroupComp = TargetGroupSingleton.Instance.GetComponent<CinemachineTargetGroup>();
        targetGroupComp.m_Targets[0].radius *= fovMultiplier;
    }

    private void OnDisable()
    {
        targetGroupComp.m_Targets[0].radius /= fovMultiplier;
    }

}
