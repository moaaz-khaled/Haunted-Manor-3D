using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>();
    public List<Vector3> Rotations = new List<Vector3>();

    void Awake()
    {
        positions.Add(new Vector3(27.55f, -2.85f, 0.4f));
        Rotations.Add(new Vector3(-57.183f , 180.448f , 89.742f));

        positions.Add(new Vector3(9.2f, 1f , -11f));
        Rotations.Add(new Vector3(-60f , 0f , 90f));

        positions.Add(new Vector3(0.7f, 1.25f, 3.5f));
        Rotations.Add(new Vector3(270f , 0f , 90f));

        positions.Add(new Vector3(-7.6f , 4.75f , -12f));
        Rotations.Add(new Vector3(270f , 90f , 90f));

        positions.Add(new Vector3(-15.8f , 4.65f , -30.55f));
        Rotations.Add(new Vector3(270f , 90f , 90f));

        positions.Add(new Vector3(-26.5f, 4.65f, -26.7f));
        Rotations.Add(new Vector3(270f , 90f , 90f));

        positions.Add(new Vector3(-26f, 1f, -28f));
        Rotations.Add(new Vector3(270f , 90f , 90f));

        positions.Add(new Vector3(-17.7f, 0.9f, -18f));
        Rotations.Add(new Vector3(270f , 90f , 90f));

        positions.Add(new Vector3(-29.25f, 0.9f, -11.5f));
        Rotations.Add(new Vector3(270f , 90f , 90f));

        positions.Add(new Vector3(-28.3f, 1.05f, 2.5f));
        Rotations.Add(new Vector3(270f , 90f , 90f));
    }

    void Update() {
        
    }
}
