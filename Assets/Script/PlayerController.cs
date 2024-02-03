using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool GameEnd;
    public int Health;
    public float JumpForce;
    private Rigidbody2D rb;
    private EventHandler ScoreUpdatedEvent;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.Translate(-7.62f, 0, 0);

    }

    private void Update()
    {
        if (!GameEnd)
        {
            Movement();
        }

    }
    public void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 11)
        {
            Health--;
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null && Health == 0)
            {
                gameManager.GameOver();
                Destroy(this.gameObject);
            }


        }
    }


    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.layer == 9)
        {

            ManagerContainer.Instance.Score.AddScore();
            ScoreUpdatedEvent.Invoke(this, EventArgs.Empty);
        }
    }

    public void AddEvent()
    {
        ScoreUpdatedEvent += ManagerContainer.Instance.Score.OnScoreUpdated;
    }

    public void Build()
    {

    }


}
