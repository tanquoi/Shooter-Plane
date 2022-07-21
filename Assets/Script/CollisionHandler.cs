using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.name + "--Collided with--" + collision.gameObject.name);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}");
    }
}
