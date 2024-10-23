using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float force;
    void Start()
    {
        Collider[] objs = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider obj in objs)
        {
            if(obj.GetComponent<Rigidbody>())
            {
                Debug.Log("Collision");
                Rigidbody rb= obj.GetComponent<Rigidbody>();
                rb.AddForce(( transform.position -obj.transform.position ) *force,ForceMode.Impulse);
            }
        }
    }

    
}
