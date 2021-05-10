﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlaceAnchor : MonoBehaviour
{
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARRaycastManager m_RaycastManager;
    ARAnchorManager m_AnchorManager;
    List<ARAnchor> m_AnchorsList;
    ARPlaneManager m_PlaneManager;
    //Remove all reference points created
    public void RemoveAllReferencePoints()
    {
        foreach (var anchor in m_AnchorsList)
        {
            Destroy(anchor);
        }
        m_AnchorsList.Clear();
    }


    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
        m_AnchorManager = GetComponent<ARAnchorManager>();
        m_PlaneManager = GetComponent<ARPlaneManager>();
        m_AnchorsList = new List<ARAnchor>();
    }

    private void OnDestroy()
    {
        
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
            return;

        if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = s_Hits[0].pose;
            TrackableId planeId = s_Hits[0].trackableId; //get the ID of the plane hit by the raycast
            var referencePoint = m_AnchorManager.AttachAnchor(m_PlaneManager.GetPlane(planeId), hitPose);
            if (referencePoint != null)
            {
                RemoveAllReferencePoints();
                m_AnchorsList.Add(referencePoint);
            }
        }
    }

}
