using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBufferTarget : Life
{
    protected override void Die()
    {
        PlayerManager.instance._nextBalloonSpawnAmount++;
        base.Die();
    }
}
