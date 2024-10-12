using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody targetRb;


    public int pointValue;
    float minSpeed = 12;
    float maxSpeed = 16;
    float maxTorque = 10;
    float xRange = 4;
    float ySpawnPoint = -2;
    GameManager gameManager;

    public ParticleSystem explosionPs;

    void Start()
    {
        //targetRb = GetComponent<Rigidbody>();
        //targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        //targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        //transform.position = RandomPos();
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();

    }

    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPoint);
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private void OnMouseDown()
    {


    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionPs, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
