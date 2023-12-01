using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Move(Transform finish)
    {
        transform.position = Vector3.MoveTowards(transform.position, finish.position, speed * Time.deltaTime);
    }
}
