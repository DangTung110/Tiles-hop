using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubePoolManager poolManager;
    private float timeSpawn = 0.98f;

    private void Update()
    {
        CubeSpawn();
    }
    private void CubeSpawn()
    {
        timeSpawn -= Time.deltaTime;
        if (timeSpawn < 0f)
        {
            GameObject cube = poolManager.GetCube();
            if (cube != null)
            {
                cube.transform.position = transform.position + Vector3.right * Random.Range(-1.2f, 1.2f);
                cube.SetActive(true);
                poolManager.StartCoroutine(poolManager.ReturnCubeToPool(cube));
            }
            timeSpawn = 0.98f;
        }
    }
}
