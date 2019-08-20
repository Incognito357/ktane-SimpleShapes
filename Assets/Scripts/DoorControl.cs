using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour {
    public MoveTarget leftDoor;
    public MoveTarget rightDoor;
    public MoveTarget openings;
    public float doorDuration = 0.5f;

    public Shape[] shapes
    {
        get; private set;
    }

    public Shape currentShape
    {
        get; private set;
    }

    private float animStart;

    private bool opening = false;
    private bool closing = false;

    public void OpenDoors()
    {
        if (opening) return;
        if (currentShape != null) currentShape.gameObject.SetActive(false);
        currentShape = shapes[Random.Range(0, shapes.Length)];
        currentShape.gameObject.SetActive(true);

        leftDoor.animate(Vector3.left * 0.05f, doorDuration);
        rightDoor.animate(Vector3.right * 0.05f, doorDuration);
        opening = true;
        closing = false;
    }

    public void CloseDoors()
    {
        if (closing) return;
        openings.animate(Vector3.down * 0.0225f, doorDuration);
        closing = true;
        opening = false;
    }

    void Start()
    {
        shapes = openings.GetComponentsInChildren<Shape>(true);
    }
	
	void Update () {
        if (opening)
        {
            if (leftDoor.percentComplete > 0.75f && !openings.animating)
            {
                openings.animate(Vector3.zero, doorDuration);
            }

            if (!leftDoor.animating && !rightDoor.animating && !openings.animating)
            {
                opening = false;
            }
        }

        if (closing)
        {
            if (openings.percentComplete > 0.75f && !leftDoor.animating)
            {
                leftDoor.animate(Vector3.zero, doorDuration);
                rightDoor.animate(Vector3.zero, doorDuration);
            }

            if (!leftDoor.animating && !rightDoor.animating && !openings.animating)
            {
                closing = false;
            }
        }
    }
}
