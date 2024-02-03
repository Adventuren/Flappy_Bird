using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Update()
    {
        if (ManagerContainer.Instance.Game.GameEnded == false)
        {
            transform.position -= Vector3.right * ManagerContainer.Instance.Speed.GameSpeed * Time.deltaTime;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 8)
        {
            gameObject.SetActive(false);
        }
    }



}

