using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Vector3 look = new Vector3(15, 25, 15);
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.RotateAround(look, Vector3.up,  10 * Time.deltaTime);
    }
}
