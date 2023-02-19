using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltingPeg : MonoBehaviour
{
    [SerializeField] float tiltSpeed = 1f;

    void Update()
    {
        //TODO: Make rotate back and forth between 30 and -30 degrees.
        transform.Rotate(0f, 0f, tiltSpeed * Time.deltaTime, Space.Self);
    }
}
