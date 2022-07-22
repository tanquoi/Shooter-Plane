using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timedestroy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timedestroy);
    }

    // Update is called once per frame
    
}
