using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FishCapture
{
    // A Test behaves as an ordinary method
    [Test]
    public void FishCaptured()
    {
        Assert.AreEqual(new Vector3(0, 0, 1), Movements.DirectionF);
    }
}
