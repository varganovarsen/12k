using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New obstacle", menuName = "Obstacle")]
public class Obstacle : ScriptableObject
{
    public GameObject obstaclePrefab;
    public float depth = 0;
}
