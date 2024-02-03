using UnityEngine;

public class Powerup_Shield : MonoBehaviour
{
    private PlayerController player;

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
            if (player == null)
            {

                player = other.GetComponent<PlayerController>();
            }

            if (player != null)
            {
                player.Health++;
            }

            Destroy(this.gameObject);
        }
    }
}
