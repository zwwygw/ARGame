using UnityEngine;

public class ShellContrller : MonoBehaviour
{
    public float speed = 15f;
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
