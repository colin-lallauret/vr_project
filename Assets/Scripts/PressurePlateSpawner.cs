using UnityEngine;

public class PressurePlateSpawner : MonoBehaviour
{
    public GameObject diamondCube;
    public GameObject carrotPrefab;
    public Transform carrotSpawnPoint;
    private bool isCubeOnPlate = false;
    private float spawnInterval = 1f;
    private float spawnRange = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == diamondCube)
        {
            isCubeOnPlate = true;
            InvokeRepeating("SpawnCarrot", 0f, spawnInterval);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == diamondCube)
        {
            isCubeOnPlate = false;
            CancelInvoke("SpawnCarrot");
        }
    }

    private void SpawnCarrot()
    {
        if (isCubeOnPlate)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-spawnRange, spawnRange),
                0f,
                Random.Range(-spawnRange, spawnRange)
            );

            Instantiate(carrotPrefab, carrotSpawnPoint.position + randomOffset, Quaternion.identity);
        }
    }
}
