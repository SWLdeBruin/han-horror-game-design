using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateFood : MonoBehaviour
{
    private float rotationSpeed = 65f; // rotation speed in degrees per second

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 0), rotationSpeed * Time.deltaTime * Random.Range(0.5f, 1.5f));
    }
}
