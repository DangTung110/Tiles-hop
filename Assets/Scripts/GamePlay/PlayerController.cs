using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Material[]               playerMaterials;
    public static PlayerController  instance;
    private Renderer    playerRenderer;
    private Rigidbody   rb;
    private Camera      camera;
    private float       distance = 0f;

    void Awake()
    {
        playerRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    private void Start()
    {
        if (instance == null)
            instance = this;
        playerRenderer.material = playerMaterials[Random.Range(0, 14)];
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        ChangeVertical();
        ChangeHorizontal();
    }
    private void ChangeVertical()
    {
        Vector3 temp = rb.position;
        temp.y = Mathf.Clamp(temp.y, 0f, 5f);
        rb.position = temp;
    }
    private void ChangeHorizontal()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 22f));
        if (Input.GetMouseButtonDown(0))    
            distance = mousePos.x - rb.position.x;
        if (Input.GetMouseButton(0))
        {
            mousePos.x = mousePos.x - distance;
            mousePos.y = rb.position.y;
            mousePos.z = rb.position.z;
            rb.position = mousePos;
        }
    }
}
