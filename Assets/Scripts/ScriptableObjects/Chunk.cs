using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Chunk", menuName = "Chunk")]
public class Chunk : ScriptableObject
{
    public int chunkSize;
    public List<Obstacle> obstacles;
}
