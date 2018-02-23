using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ControllerGoogleAR
    : MonoBehaviour
{
    public GameObject prefabPlane;

    private List<TrackedPlane> m_NewPlanes = new List<TrackedPlane>();
    private List<TrackedPlane> m_AllPlanes = new List<TrackedPlane>();

    public void Update()
    {
        if (Frame.TrackingState != TrackingState.Tracking)
            return;

        Frame.GetPlanes(m_NewPlanes, TrackableQueryFilter.New);

        for (int i = 0; i < m_NewPlanes.Count; i++)
        {
            var plane = GameObject.Instantiate(prefabPlane, transform);
            var visualizer = plane.GetComponent<GoogleARCore.HelloAR.TrackedPlaneVisualizer>();

            visualizer.Initialize(m_NewPlanes[i]);
        }

        //Frame.GetPlanes(m_AllPlanes);
        //Touch touch;
        //if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        //{
            //return;
        //}
    }
}
