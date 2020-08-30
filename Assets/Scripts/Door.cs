using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject currentRoom;
    [SerializeField] private GameObject nextRoom;
    [SerializeField] private Collider collider;

    public void EnableDoor()
    {
        collider.enabled = true;
    }

    public void DisableDoor()
    {
        collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
            UIController.Instance.EnableButtom(currentRoom, nextRoom);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            UIController.Instance.DisableButtom();
    }
}
