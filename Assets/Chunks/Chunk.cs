using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public enum YConnection
    {
        Down = -1,
        Straight = 0,
        Up = 1,
    }
    public enum XConnection
    {
        Left = -1,
        Straight = 0,
        Right = 1,
    }

    [Serializable]
    public struct Gate
    {
        public XConnection xConnection;
        public YConnection yConnection;
    }

}
