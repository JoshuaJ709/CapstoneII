using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent uEvent;


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Triggered by: {other.name}, tag: {other.tag}");
        if (other.CompareTag("Player"))
            Debug.Log("Trigger Successful!");
            uEvent.Invoke();
    }
}