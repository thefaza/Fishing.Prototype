using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ExtendedBehavior
{
    public float speed = 0.5f;
    public float xLimit = 0.9f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }

        var axis = Input.GetAxis("Horizontal");

        if (transform.localPosition.x <= -xLimit && axis < 0)
        {
            return;
        }

        if (transform.localPosition.x >= xLimit && axis > 0)
        {
            return;
        }

        gameObject.transform.position += Vector3.right * axis * Time.deltaTime * speed;

    }
}
