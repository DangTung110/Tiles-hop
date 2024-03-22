using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Material[] playerMaterials;
    private Renderer playerRenderer;

    void Awake()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        playerRenderer.material = playerMaterials[Random.Range(0, 14)];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
