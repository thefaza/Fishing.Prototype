using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : ExtendedBehavior
{
    public List<GameObject> spawnList;
    // Start is called before the first frame update
    public Transform player; // Reference to the player’s transform
    public float throwForce = 1f; // Force applied when throwing the item
    private void Start()
    {

        StartCoroutine(SpawnItems());
    }

    private IEnumerator SpawnItems()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            GameObject itemToSpawn = spawnList[Random.Range(0, spawnList.Count)];

            Vector3 randomSpawnPosition = GetRandomSpawnPosition();
            GameObject spawnedItem = Instantiate(itemToSpawn, randomSpawnPosition, itemToSpawn.transform.rotation);
            ThrowItem(spawnedItem);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-0.9f, 0.9f), Random.Range(5f, 10f), 0);

        return randomDirection;
    }

    private void ThrowItem(GameObject item)
    {
        // Get the Rigidbody component of the spawned item
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Calculate the direction to throw the item towards the player
            Vector3 throwDirection = (player.position - item.transform.position).normalized;

            // Apply force to throw the item
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
            rb.AddTorque(throwDirection * throwForce, ForceMode.Impulse);
        }
    }
}
