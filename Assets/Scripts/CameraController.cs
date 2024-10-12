using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float initialZPointOfCamera = -10.0f;

    private int _mode;
    // ENCAPSULATION
    public int Mode
    {

        get
        {
            return _mode;
        }

        set
        {
            if (_mode < 0 || _mode > 3)
            {
                throw new System.Exception("Not supported camera mode");
            }

            _mode = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetCamera(0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.z > UPPER_LIMIT)
        //{
        //    reverseDirection;
        //}
        HandleCamera();
    }
    public void SetCamera(int cameraMode)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, initialZPointOfCamera);
        _mode = cameraMode;
    }
    void CameraMode_0()
    {
        if (transform.position.z < 0)
            gameObject.transform.SetPositionAndRotation(transform.position + new Vector3(0, 0, 0.05f) * Time.deltaTime, transform.rotation);

    }
    void CameraMode_1()
    {
        if (transform.position.z < 0)
            gameObject.transform.SetPositionAndRotation(transform.position + new Vector3(0, 0.05f, 0) * Time.deltaTime, transform.rotation);

    }
    void CameraMode_2()
    {
        gameObject.transform.SetPositionAndRotation(transform.position + new Vector3(0, 0.05f, 0) * Time.deltaTime, transform.rotation);

    }
    private void HandleCamera()
    {
        if (_mode == 0)
        {
            CameraMode_0();
        }
        else if (_mode == 1)
        {
            CameraMode_1();
        }
        else if (_mode == 2)
        {
            CameraMode_2();
        }
    }

}