using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellContrller : MonoBehaviour
{
    private Transform firePos;

    public float speed = 15f;
    public KeyCode fireKey = KeyCode.KeypadEnter;
    public GameObject shelPref;
    //public AudioClip shotAudio;
    // Start is called before the first frame update
    void Start()
    {
        firePos = transform.Find("shellPos");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
          //  AudioSource.PlayClipAtPoint(shotAudio, transform.position);
            GameObject shell = GameObject.Instantiate(shelPref, firePos.position, firePos.rotation) as GameObject;
            shell.GetComponent<Rigidbody>().velocity = shell.transform.forward * speed;
        }
    }
}
