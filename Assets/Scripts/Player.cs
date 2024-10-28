using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Generation gen;
    private Vector3 startPos;
    private Vector2 mapSize;
    void Update()
    {   
        Move();
        Vector3 position = transform.position;
        
        position.x = Mathf.Clamp(position.x, startPos.x- mapSize.x / 2, startPos.x+ mapSize.x / 2);
        position.z = Mathf.Clamp(position.z, startPos.z- mapSize.y / 2, startPos.z+ mapSize.y / 2);
        transform.position = position;

    }
    private void Move()
    {
        transform.Translate(new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")) * Time.deltaTime * speed);
    }
    private void Start()
    {
        mapSize = gen.getMapSize();
        transform.position = new Vector3(mapSize.x/2-1, 0, mapSize.y/2+2);
        startPos = transform.position;
    }
}
