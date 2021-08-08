using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    public GameObject prefabToPlace;

    private GameObject instantiatedPrefab;
    private ARRaycastManager m_RaycastManager;
    private ARAnchorManager m_AnchorManager;
    private ARPlaneManager m_PlaneManager;
    private ARAnchor anchor;

    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
        m_AnchorManager = GetComponent<ARAnchorManager>();
        m_PlaneManager = GetComponent<ARPlaneManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
        if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {

            Pose hitPose = s_Hits[0].pose; // Raycast hits are sorted by distance, so first is the closest hit.
            TrackableId planeId = s_Hits[0].trackableId; // get the ID of the plane hit by the raycast

            Destroy(anchor); // Remove the old anchor before adding a new one
            anchor = m_AnchorManager.AttachAnchor(m_PlaneManager.GetPlane(planeId), hitPose);

            if (instantiatedPrefab == null)
            {
                instantiatedPrefab = Instantiate(prefabToPlace);
            }
            instantiatedPrefab.transform.parent = anchor.transform;
            instantiatedPrefab.transform.localPosition = Vector3.zero;
        }
    }
}
