using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void CardinalMovement()
    {
        Assert.AreEqual(new Vector3(0, 0, 1), Movements.DirectionF);
        Assert.AreEqual(new Vector3(0, 0, -1), Movements.DirectionB);
        Assert.AreEqual(new Vector3(1, 0, 0), Movements.DirectionL);
        Assert.AreEqual(new Vector3(-1, 0, 0), Movements.DirectionR);
    }
    [Test]
    public void Complex()
    {
        float walkSpeed = 0.5f;
        float sprintSpeed = 4f;
        Assert.AreEqual(new Vector3(0, 1, 0), Movements.Jump);
        Assert.AreEqual(walkSpeed, Movements.Walk);
        Assert.AreEqual(sprintSpeed, Movements.Sprint);
    }
}
