using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour {
    private Vector3 origin;
    private Vector3 target;
    private float duration;
    private float animStart;
    public float percentComplete { get; private set; }
    public bool animating { get; private set; }

    public void animate(Vector3 target, float duration)
    {
        origin = transform.localPosition;
        this.target = target;
        this.duration = duration;
        animStart = Time.time;
        animating = true;
        percentComplete = 0.0f;
    }

    void Update()
    {
        if (animating)
        {
            float curDuration = Time.time - animStart;
            percentComplete = curDuration / duration;

            transform.localPosition = Vector3.Lerp(origin, target, percentComplete);

            if (percentComplete > 1.0f)
            {
                animating = false;
                percentComplete = 100.0f;
            }
        }
    }
}
