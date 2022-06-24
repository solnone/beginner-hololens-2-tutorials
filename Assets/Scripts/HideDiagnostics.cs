using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Diagnostics;
using UnityEngine;

public class HideDiagnostics : MonoBehaviour
{
    void Start()
    {
        if (MixedRealityServiceRegistry.TryGetService<IMixedRealityDiagnosticsSystem>(out IMixedRealityDiagnosticsSystem diagnosticsSystem))
        {
            diagnosticsSystem.ShowDiagnostics = false;
        }
    }
}
