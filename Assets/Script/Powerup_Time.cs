using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Time : MonoBehaviour
{
    private PlayerController player;
    private Coroutine powerupCoroutine;

    private void Update()
    {
        if (ManagerContainer.Instance.Game.GameEnded == false)
        {
            transform.position -= Vector3.right * ManagerContainer.Instance.Speed.GameSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (powerupCoroutine != null)
            {
                Debug.Log("Before StopCoroutine: " + powerupCoroutine);
                StopCoroutine(powerupCoroutine);
                Debug.Log("After StopCoroutine: " + powerupCoroutine);

            }

            powerupCoroutine = StartCoroutine(Poweruptime());
            GetComponent<Renderer>().enabled = false;
        }
    }

    IEnumerator Poweruptime()
    {
        ManagerContainer.Instance.Speed.GameSpeed = 3f;
        ManagerContainer.Instance.Input.SpawnTime = 1.5f;
        
        yield return new WaitForSecondsRealtime(3);
        
        ManagerContainer.Instance.Speed.GameSpeed = 6f;
        ManagerContainer.Instance.Input.SpawnTime = 1f;
        Destroy(this.gameObject);
    }
}
