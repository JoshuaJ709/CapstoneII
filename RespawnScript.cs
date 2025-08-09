using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] List<GameObject> Checkpoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] float yCheckpointRotation;
    [SerializeField] MouseMovement mouseMovementScript;
    public Transform Orientation;
    [SerializeField] float dead;

    void Update()
    {
        if (Player.transform.position.y < -dead)
        {
    // Move player to checkpoint position
    Player.transform.position = vectorPoint;

    // Rotate player and orientation
    Orientation.transform.rotation = Quaternion.Euler(0, yCheckpointRotation, 0);
    Player.transform.rotation = Quaternion.Euler(0, yCheckpointRotation, 0);

    // Reset mouse look direction
    mouseMovementScript.SetLookRotation(yCheckpointRotation);

    // Zero physics
    Rigidbody rb = Player.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);

        if (other.CompareTag("DeathZone"))
        {
             Debug.Log("Death zone hit! Respawning...");

             // Move player to checkpoint position
             Player.transform.position = vectorPoint;

             // Rotate player and orientation
             Orientation.transform.rotation = Quaternion.Euler(0, yCheckpointRotation, 0);
             Player.transform.rotation = Quaternion.Euler(0, yCheckpointRotation, 0);

             // Reset mouse look direction
             mouseMovementScript.SetLookRotation(yCheckpointRotation);

             // Zero physics
             Rigidbody rb = Player.GetComponent<Rigidbody>();

             if (rb != null)
             {
                 rb.linearVelocity = Vector3.zero;
                 rb.angularVelocity = Vector3.zero;
             }
         }
         else if (other.CompareTag("Checkpoint"))
         {
             vectorPoint = Player.transform.position;
             yCheckpointRotation = other.gameObject.transform.eulerAngles.y + 180f;
             Destroy(other.gameObject);
            
        }
    }
}