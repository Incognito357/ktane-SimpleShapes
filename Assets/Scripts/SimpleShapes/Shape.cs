using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {
    public enum Geometry
    {
        Triangle, Square, Pentagon, Hexagon, Octagon, Rhombus, Moon, Star, Plus
    }

    public Geometry shape;
    public bool isOpening;
}
