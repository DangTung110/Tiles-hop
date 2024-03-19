using System.Collections.Generic;
using UnityEngine;

public class CubePoolManager : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private int poolSize;
    [SerializeField] private List<GameObject> cubePool;

    private void Start()
    {
        CreateCubePool();
    }
    private void CreateCubePool()
    {
        cubePool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newCube = Instantiate(cubePrefab, gameObject.transform);
            newCube.SetActive(false);
            cubePool.Add(newCube);
        }
    }
    public GameObject GetCube()
    {
        for (int i = 0; i < cubePool.Count; i++) 
        {
            if (!cubePool[i].activeInHierarchy)
                return cubePool[i];
        }
        return null;
    }
    public void ReturnCubeToPool(GameObject cube)
    {
        cube.SetActive(false);
    }
}
