using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.Splines;
using static UnityEngine.Rendering.DebugUI.Table;

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
            var newChunk = Instantiate(found.prefab);
            newChunk.transform.name = i.ToString();

            List<BezierKnot> knotCollec = (List<BezierKnot>)_loadedChunks[i-1].Find("Spline").GetComponent<SplineContainer>().Spline.Knots;
            var lastKnot = knotCollec[knotCollec.Count - 1];
            Transform splineTransform = _loadedChunks[i - 1].Find("Spline");
            var newKnotCollec = (List<BezierKnot>)found.prefab.Find("Spline").GetComponent<SplineContainer>().Spline.Knots;
            var newKnotBegin = newKnotCollec[0];
            var newKnotEnd = newKnotCollec[newKnotCollec.Count - 1];

            Quaternion rotationValue = (Quaternion)lastKnot.Rotation  * _loadedChunks[i - 1].transform.rotation;

            Vector3 dif = rotationValue * (Vector3)(newKnotEnd.Position - newKnotBegin.Position);

            int xSign = dif.x >= 0? -1 : 1;
            //int ySign = dif.y >= 0? 1 : -1;
            int ySign = 1;
            int zSign = dif.z >= 0? -1 : 1;

            // the commented calculus should work for trigo oriented rotations, need to be tested
            //Vector3 newPos = new Vector3(xSign * _loadedChunks[i - 1].position.x, ySign * _loadedChunks[i - 1].position.y, zSign * _loadedChunks[i - 1].position.z);
            Vector3 newPos = new Vector3(zSign * _loadedChunks[i - 1].position.z, ySign * _loadedChunks[i - 1].position.y, xSign * _loadedChunks[i - 1].position.x);
            Debug.Log($"newPos1: {newPos}");
            newPos += (Vector3)lastKnot.Position - (Vector3)newKnotBegin.Position;
            Debug.Log($"newPos2: {newPos} + {lastKnot.Position}");

            newChunk.position = newPos;// - (Vector3)newKnot.Position;




            Debug.Log($"signs: {xSign} + {ySign} + {zSign}");

            newChunk.rotation = rotationValue;

            Debug.Log($"Set up chunk :{newChunk.name}");

            _loadedChunks.Add(newChunk);
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
