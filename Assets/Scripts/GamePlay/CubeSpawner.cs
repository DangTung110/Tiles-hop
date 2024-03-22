using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubePoolManager poolManager;
    private float timeSpawn = 0.5f;

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
                cube.transform.position = new Vector3(transform.position.x + Random.Range(-1.2f, 1.2f), transform.position.y, transform.position.z);
                cube.SetActive(true);
                poolManager.StartCoroutine(poolManager.ReturnCubeToPool(cube));
            }
            timeSpawn = Random.Range(0.3f, 0.8f);
        }
        
    }
}
