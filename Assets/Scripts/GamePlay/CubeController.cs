using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float speed = 10f;
    void LateUpdate()
    {
        CubeMovement();
    }

    private void CubeMovement()
    {
        transform.position -= Vector3.forward * speed * Time.deltaTime;
    }
}
