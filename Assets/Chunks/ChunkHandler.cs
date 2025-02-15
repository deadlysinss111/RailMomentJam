using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkHandler : MonoBehaviour
{
    [SerializeField] int loadedChunksAmount = 16;
    [SerializeField] ChunkLibrary chunkLibrary;

    List<Transform> _loadedChunks;
    List<ChunkData> _loadedChunksData;

    private void Awake()
    {
        _loadedChunks = new List<Transform>(loadedChunksAmount);
        _loadedChunksData = new List<ChunkData>(loadedChunksAmount);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadChunk();
        }
    }

    private void Start()
    {
        _loadedChunksData.Add(chunkLibrary.library[Random.Range(0, chunkLibrary.library.Count)]);
        _loadedChunks.Add(Instantiate(_loadedChunksData[0].prefab));
        for (int i = 1; i < loadedChunksAmount; i++)
        {
            List<ChunkData> matching = GetMatchingChunks(_loadedChunksData[i - 1].gate.xConnection, _loadedChunksData[i - 1].gate.yConnection);
            ChunkData found = matching[Random.Range(0, matching.Count)];
            _loadedChunksData.Add(found);
            _loadedChunks.Add(Instantiate(found.prefab, _loadedChunks[i - 1].Find("End").transform.position, _loadedChunks[i - 1].Find("End").transform.rotation));
        }
    }

    List<ChunkData> GetMatchingChunks(Chunk.XConnection xCon,  Chunk.YConnection yCon)
    {
        List<ChunkData> matching = new();
        foreach (ChunkData chunk in chunkLibrary.library)
        {
            if ((int)chunk.gate.xConnection == -1 * (int)xCon && (int)chunk.gate.yConnection == -1 * (int)yCon)
            {
                matching.Add(chunk);
            }
        }
        return matching;
    }

    void LoadChunk()
    {
        Destroy(_loadedChunks[0].gameObject);
        _loadedChunksData.RemoveAt(0);
        _loadedChunks.RemoveAt(0);
        List<ChunkData> matching = GetMatchingChunks(_loadedChunksData[loadedChunksAmount - 2].gate.xConnection, _loadedChunksData[loadedChunksAmount - 2].gate.yConnection);
        ChunkData found = matching[Random.Range(0, matching.Count)];
        _loadedChunksData.Add(found);
        _loadedChunks.Add(Instantiate(found.prefab, _loadedChunks[loadedChunksAmount - 2].Find("End").transform.position, _loadedChunks[loadedChunksAmount - 2].Find("End").transform.rotation));
    }
}
