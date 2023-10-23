using UnityEngine;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class FishMovement
{
    [Test]
    public void FishMovementTest()
    {
        Assert.AreEqual(new Vector3(0, 0, 1), Movements.DirectionF);
        Assert.AreEqual(new Vector3(0, 0, -1), Movements.DirectionB);
        Assert.AreEqual(new Vector3(1, 0, 0), Movements.DirectionL);
        Assert.AreEqual(new Vector3(-1, 0, 0), Movements.DirectionR);
    }

}