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

    /// <summary>
    /// Controls the HelloAR example.
    /// </summary>
    public class HelloARController : MonoBehaviour
    {
        /// <summary>
        /// The first-person camera being used to render the passthrough camera image (i.e. AR background).
        /// </summary>
        public Camera FirstPersonCamera;

        /// <summary>
        /// A prefab for tracking and visualizing detected planes.
        /// </summary>
        public GameObject DetectedPlanePrefab;

        /// <summary>
        ///     怪物prefab.
        /// </summary>
        public GameObject Monster;

        /// <summary>
        /// A model to place when a raycast from a user touch hits a feature point.
        /// </summary>
        public GameObject AndyPointPrefab;
        public GameObject MonsterParent;
        public Button     FireBtn;
        public Transform firePos;

        public float speed = 15f;
        public GameObject shelPref;
        /// <summary>
        /// The rotation in degrees need to apply to model when the Andy model is placed.
        /// </summary>
        private const float k_ModelRotation = 180.0f;

        /// <summary>
        /// True if the app is in the process of quitting due to an ARCore connection error, otherwise false.
        /// </summary>
        private bool m_IsQuitting = false;
     

        private int num_Monster;
        /// <summary>
        /// The Unity Update() method.
        /// </summary>
        /// 
        private void Awake()
        {
            FireBtn.onClick.AddListener(delegate ()
            {
                OnClick(FireBtn.gameObject);
            });
        }
        public void Start()
        {
          
        }
        public void Update()
        {
            _UpdateApplicationLifecycle();

            // If the player has not touched the screen, we are done with this update.
            Touch touch;
            if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
            {
                return;
            }

            // Raycast against the location the player touched to search for planes.
            TrackableHit hit;
            TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
                TrackableHitFlags.FeaturePointWithSurfaceNormal;

            if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
            {
                // Use hit pose and camera pose to check if hittest is from the
                // back of the plane, if it is, no need to create the anchor.
                if ((hit.Trackable is DetectedPlane) &&
                    Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
                        hit.Pose.rotation * Vector3.up) < 0)
                {
                    Debug.Log("Hit at back of the current DetectedPlane");
                }
                else
                {
                    // Choose the Andy model for the Trackable that got hit.
                    GameObject prefab;
                    if (hit.Trackable is FeaturePoint)
                    {
                        prefab = AndyPointPrefab;
                        Debug.Log("+++++++++++++");
                    }
                    else
                    {
                        prefab = Monster; 
                        Debug.Log("***********");
                    }
                    System.Random random = new System.Random((int)DateTime.Now.Ticks);
                    num_Monster = random.Next(10, 15);
                    for (int i = 0; i <= num_Monster; i++)
                    {
                        // Instantiate Andy model at the hit pose.
                        var monsterGO = Instantiate(prefab, hit.Pose.position, hit.Pose.rotation);

                        // Compensate for the hitPose rotation facing away from the raycast (i.e. camera).
                        monsterGO.transform.Rotate(0, k_ModelRotation, 0, Space.Self);
                        // Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
                        // world evolves.
                        //    var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                        // Make Andy model a child of the anchor.
                        // andyObject.transform.parent = anchor.transform;
                        monsterGO.transform.parent = MonsterParent.transform;
                    }
                    
                }
            }
        }

        /// <summary>
        /// Check and update the application lifecycle.
        /// </summary>
        private void _UpdateApplicationLifecycle()
        {
            // Exit the app when the 'back' button is pressed.
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            // Only allow the screen to sleep when not tracking.
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

            // Quit if ARCore was unable to connect and give Unity some time for the toast to appear.
            if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
            {
                _ShowAndroidToastMessage("Camera permission is needed to run this application.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
            else if (Session.Status.IsError())
            {
                _ShowAndroidToastMessage("ARCore encountered a problem connecting.  Please start the app again.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
        }

        //UGUI按钮点击触发
        private void OnClick(GameObject go)
        {
            if(go == FireBtn.gameObject)
            {
                GameObject shell = GameObject.Instantiate(shelPref, firePos.position, firePos.rotation) as GameObject;
                shell.GetComponent<Rigidbody>().velocity = shell.transform.forward * speed;
                GameObject.Destroy(shell,2);
                
            }
        }

        /// Actually quit the application.
        private void _DoQuit()
        {
            Application.Quit();
        }

        /// Show an Android toast message.
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
