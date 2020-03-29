using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
  //  public GameManager gameManager;

    // Start is called before the first frame update
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}

   