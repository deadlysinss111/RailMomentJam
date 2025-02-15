using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class ChunkHandler : MonoBehaviour
{
    [SerializeField] int loadedChunksAmount = 16;
    [SerializeField] ChunkLibrary chunkLibrary;
    [SerializeField] SplineAnimate wagon;

    List<Transform> _loadedChunks;
    List<ChunkData> _loadedChunksData;

    private void Awake()
    {
        _loadedChunks = new List<Transform>(loadedChunksAmount);
        _loadedChunksData = new List<ChunkData>(loadedChunksAmount);
    }

    private void Update()
    {
        if (wagon.NormalizedTime >= .99f)
        {
            wagon.Container = _loadedChunks[1].Find("Spline").GetComponent<SplineContainer>();
            wagon.Restart(true);
            wagon.Play();
            LoadChunk();
        }
    }

    private void Start()
    {
        _loadedChunksData.Add(chunkLibrary.library[Random.Range(0, chunkLibrary.library.Count)]);
        _loadedChunks.Add(Instantiate(_loadedChunksData[0].prefab));
        wagon.Container = _loadedChunks[0].Find("Spline").GetComponent<SplineContainer>();
        for (int i = 1; i < loadedChunksAmount; i++)
        {
            List<ChunkData> matching = GetMatchingChunks(_loadedChunksData[i - 1].gate.xConnection, _loadedChunksData[i - 1].gate.yConnection);
            ChunkData found = matching[Random.Range(0, matching.Count)];
            _loadedChunksData.Add(found);
            List<BezierKnot> knotCollec = (List<BezierKnot>)_loadedChunks[i-1].Find("Spline").GetComponent<SplineContainer>().Spline.Knots;
            var lastKnot = knotCollec[knotCollec.Count - 1];
            //var lastKnot = knotCollec[knotCollec.Count - 1];
            Transform splineTransform = _loadedChunks[i - 1].Find("Spline");
            var newKnotCollec = (List<BezierKnot>)found.prefab.Find("Spline").GetComponent<SplineContainer>().Spline.Knots;
            var newKnot = newKnotCollec[0];
            _loadedChunks.Add(Instantiate(found.prefab, (Vector3)lastKnot.Position - (Vector3)newKnot.Position + splineTransform.position, splineTransform.rotation));
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
        List<BezierKnot> knotCollec = (List<BezierKnot>)_loadedChunks[loadedChunksAmount - 2].Find("Spline").GetComponent<SplineContainer>().Spline.Knots;
        var lastKnot = knotCollec[knotCollec.Count-1];
        Transform splineTransform = _loadedChunks[loadedChunksAmount - 2].Find("Spline");
        var newKnotCollec = (List<BezierKnot>)found.prefab.Find("Spline").GetComponent<SplineContainer>().Spline.Knots;
        var newKnot = newKnotCollec[0];
        _loadedChunks.Add(Instantiate(found.prefab, (Vector3)lastKnot.Position - (Vector3)newKnot.Position + splineTransform.position, splineTransform.rotation));
    }
}
