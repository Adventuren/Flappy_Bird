using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public float SpawnTime;


    private void Start()
    {
        SpawnTime = 1f;
    }

    private void Update()
    {
        if(ManagerContainer.Instance.Game.GameEnded == true)
        {
            StopAllCoroutines();
        }
    }

    public IEnumerator SpawnRoutine()
    {
        ManagerContainer.Instance.Spawn.SpawnObstacle();
        yield return new WaitForSeconds(SpawnTime);
        StartCoroutine(SpawnRoutine());

    }

    public void Build()
    {
        ManagerContainer.Instance.Spawn.Build();

    }
}