using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[Serializable]
public struct ChunkData
{
    public Transform prefab;
    public Chunk.Gate gate;
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ChunkLibrary : ScriptableObject
{
    public List<ChunkData> library;
}
