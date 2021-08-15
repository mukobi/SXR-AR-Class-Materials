using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// A component that can be used to access the most recently received basic light estimation information
/// for the physical environment as observed by an AR device.
/// 
/// Based off https://github.com/Unity-Technologies/arfoundation-samples/blob/main/Assets/Scripts/BasicLightEstimation.cs
/// </summary>
[RequireComponent(typeof(Light))]
public class AdvancedLightEstimation : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The ARCameraManager which will produce frame events containing light estimation information.")]
    ARCameraManager m_CameraManager;

    void Awake()
    {
        m_Light = GetComponent<Light>();
    }

    void OnEnable()
    {
        if (m_CameraManager != null)
            m_CameraManager.frameReceived += FrameChanged;
    }

    void OnDisable()
    {
        if (m_CameraManager != null)
            m_CameraManager.frameReceived -= FrameChanged;
    }

    void FrameChanged(ARCameraFrameEventArgs args)
    {
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            m_Light.intensity = args.lightEstimation.averageBrightness.Value;
        }

        if (args.lightEstimation.averageColorTemperature.HasValue)
        {
            m_Light.colorTemperature = args.lightEstimation.averageColorTemperature.Value;
        }

        if (args.lightEstimation.mainLightColor.HasValue)
        {
            m_Light.color = args.lightEstimation.mainLightColor.Value;
        }

        if (args.lightEstimation.mainLightDirection.HasValue)
        {
            m_Light.transform.rotation = Quaternion.LookRotation(args.lightEstimation.mainLightDirection.Value);
        }
    }

    Light m_Light;
}
