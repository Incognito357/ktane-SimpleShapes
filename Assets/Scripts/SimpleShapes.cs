using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShapes : MonoBehaviour {
    public DoorControl door;
    private BoxCollider trigger;
    private bool isOpen = false;

    public void Awake()
    {
        KMNeedyModule needy = GetComponent<KMNeedyModule>();
        needy.OnNeedyActivation += OnNeedyActivation;
        needy.OnNeedyDeactivation += OnNeedyDeactivation;
        needy.OnTimerExpired += OnTimerExpired;
        trigger = GetComponent<BoxCollider>();
        trigger.enabled = false;
    }

    protected void OnNeedyActivation()
    {
        door.OpenDoors();
        isOpen = true;
        trigger.enabled = true;
    }

    protected void OnNeedyDeactivation()
    {
        door.CloseDoors();
        isOpen = false;
        trigger.enabled = false;
    }

    protected void OnTimerExpired()
    {
        GetComponent<KMNeedyModule>().HandleStrike();
        door.CloseDoors();
        isOpen = false;
        trigger.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (isOpen)
        {
            Shape shape = other.GetComponent<Shape>();
            if (shape != null && shape.shape == door.currentShape.shape)
            {
                GetComponent<KMNeedyModule>().HandlePass();
                Destroy(shape.gameObject);
            }
        }
    }
}
