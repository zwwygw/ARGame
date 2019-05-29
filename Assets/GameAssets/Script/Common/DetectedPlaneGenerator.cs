namespace GoogleARCore.Examples.Common
{
    using System.Collections.Generic;
    using GoogleARCore;
    using UnityEngine;

    public class DetectedPlaneGenerator : MonoBehaviour
    {
        public GameObject DetectedPlanePrefab;

        private List<DetectedPlane> m_NewPlanes = new List<DetectedPlane>();
        private GameObject planeObject;


        public void Update()
        {
                
            if (ARGame.sGameManage.getStartDectedPlane())
            {    
                if (Session.Status != SessionStatus.Tracking)
                {
                    return;
                }

                Session.GetTrackables<DetectedPlane>(m_NewPlanes, TrackableQueryFilter.New);
                for (int i = 0; i < m_NewPlanes.Count; i++)
                {
                    planeObject = Instantiate(DetectedPlanePrefab, Vector3.zero, Quaternion.identity, transform);
                    planeObject.GetComponent<DetectedPlaneVisualizer>().Initialize(m_NewPlanes[i]);
                }
            }
            else
            {
                if(planeObject!=null)
                {
                    GameObject.Destroy(planeObject);
                }
            }
           
        }
    }
}
