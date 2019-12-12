using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotator : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    
    [SerializeField]
    protected Vector3 axis;


    private void Update()
    {
        transform.Rotate(axis * speed * Time.deltaTime);
    }
}
