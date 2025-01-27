﻿

namespace GoogleARCore.Examples.HelloAR
{
    using System;
    using System.Collections.Generic;
    using GoogleARCore;
    using GoogleARCore.Examples.Common;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;

#if UNITY_EDITOR
    // Set up touch input propagation while using Instant Preview in the editor.
    using Input = InstantPreviewInput;
    using Random = System.Random;
#endif

    public class ARController : MonoBehaviour
    {
        
        public Camera FirstPersonCamera;
        public GameObject DetectedPlanePrefab;
        public GameObject Platform;

        private const float k_ModelRotation = 180.0f;

        private bool m_IsQuitting = false;
        private int num_Monster;

        public void Start()
        {
          
        }
        public void Update()
        {
            if (ARGame.sGameManage.getStartDectedPlane())
            {
                _UpdateApplicationLifecycle();
                Touch touch;
                if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
                {
                    return;
                }
                TrackableHit hit;
                TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
                    TrackableHitFlags.FeaturePointWithSurfaceNormal;

                if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
                {
                    if ((hit.Trackable is DetectedPlane) &&
                        Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
                            hit.Pose.rotation * Vector3.up) < 0)
                    {
                        Debug.Log("Hit at back of the current DetectedPlane");
                    }
                    else
                    {
                        GameObject prefab;
                        if (hit.Trackable is FeaturePoint)
                        {
                            return;
                        }
                        else
                        {
                            prefab = Platform;
                        }
                        var platforGo = Instantiate(prefab, hit.Pose.position, hit.Pose.rotation);
                        platforGo.transform.Rotate(0, k_ModelRotation, 0, Space.Self);
                        ARGame.sGameManage.StartGame();
                    }
                }
            }
            
        }

        private void _UpdateApplicationLifecycle()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (Session.Status != SessionStatus.Tracking)
            {
                const int lostTrackingSleepTimeout = 15;
                Screen.sleepTimeout = lostTrackingSleepTimeout;
            }
            else
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }

            if (m_IsQuitting)
            {
                return;
            }

            if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
            {
                _ShowAndroidToastMessage("需要获得照相机权限.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
            else if (Session.Status.IsError())
            {
                _ShowAndroidToastMessage("ARCore组件出现问题请重启APP.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
        }

        private void _DoQuit()
        {
            Application.Quit();
        }

        private void _ShowAndroidToastMessage(string message)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if (unityActivity != null)
            {
                AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
                unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity,
                        message, 0);
                    toastObject.Call("show");
                }));
            }
        }
    }
}
