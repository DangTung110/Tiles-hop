using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private Transform cubeSpawnPoint;

    private float speed = 15f;
    private int cubeCount = 0;
    private CubePoolManager poolManager;
    void LateUpdate()
    {
        CubeMovement();
    }

    private void CubeMovement()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
