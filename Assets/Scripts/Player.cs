using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")) * Time.deltaTime * speed);
    }
}
