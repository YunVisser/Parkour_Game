using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerMovement playermovement;
    private void OnTriggerEnter(Collider other)
    {
            playermovement.Grounded();
    }
}
