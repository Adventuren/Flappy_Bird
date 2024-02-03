using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public Transform Spawnpos1 { get; set; }
    public Transform Spawnpos2 { get; set; }
    private Vector3 _powerupSpawnPos;




    public List<GameObject> obstaclePool = new List<GameObject>();
    private int poolSize = 10;

    private void Start()
    {
        Build();
        InitializeObjectPool();
    }

    private void InitializeObjectPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstacle = InstantiateObstacle();
            obstacle.SetActive(false);
            obstaclePool.Add(obstacle);
        }
        StartCoroutine(ManagerContainer.Instance.Input.SpawnRoutine());
    }

    private GameObject InstantiateObstacle()
    {
        var randomSpawnPos = new Vector3(Spawnpos1.position.x, Random.Range(Spawnpos1.position.y, Spawnpos2.position.y), Spawnpos1.position.z);
        string path = "Sprites/Pipe";
        var obstacleToBeInstantiated = Resources.Load(path) as GameObject;

        if (obstacleToBeInstantiated != null)
        {
            return Instantiate(obstacleToBeInstantiated, randomSpawnPos, Quaternion.identity);
        }

        return null;
    }

    public void SpawnObstacle()
    {
        GameObject obstacle1 = GetPooledObstacle();
        var randomSpawnPos = new Vector3(Spawnpos1.position.x, Random.Range(Spawnpos1.position.y, Spawnpos2.position.y), Spawnpos1.position.z);
        if (obstacle1 != null)
        {
            obstacle1.SetActive(true);
            obstacle1.transform.position = randomSpawnPos;
            _powerupSpawnPos = randomSpawnPos;
            AllowSpawnPowerup();
        }
    }

    private GameObject GetPooledObstacle()
    {
        for (int i = 0; i < obstaclePool.Count; i++)
        {
            if (obstaclePool[i] != null && !obstaclePool[i].activeInHierarchy)
            {
                return obstaclePool[i];
            }
        }

        GameObject obstacle = InstantiateObstacle();
        obstaclePool.Add(obstacle);

        return obstacle;
    }

    void SpawnPowerup()
    {
        
        string randomPowerup = (Random.Range(0, 2) == 0) ? "Powerup_Shield" : "Powerup_Time";

        string path = "Sprites/" + randomPowerup;
        GameObject powerupPrefab = Resources.Load<GameObject>(path);

        if (powerupPrefab != null)
        {
            Instantiate(powerupPrefab, _powerupSpawnPos, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Powerup prefab not found at path: " + path);
        }
    }

    public void AllowSpawnPowerup()
    {
        var random = Random.Range(0, 4);
        if (random == 0)
        {
            SpawnPowerup();
        }
    }


    public void Build()
    {
        Spawnpos1 = ManagerContainer.Instance.SpawnPos1;
        Spawnpos2 = ManagerContainer.Instance.SpawnPos2;
        _powerupSpawnPos = new Vector3();

    }
}
