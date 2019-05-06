using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellExp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        GameObject.Destroy(this.gameObject);

        if (other.tag == "monster")
        {
            other.SendMessage("Damage");
        }
    }
}
