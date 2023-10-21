using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void Forward()
    {
        Assert.AreEqual(new Vector3(0, 0, 1), Movements.DirectionF);
    }
    [Test]
    public void Backward()
    {
        Assert.AreEqual(new Vector3(0, 0, -1), Movements.DirectionB);
    }
    [Test]
    public void Left()
    {
        Assert.AreEqual(new Vector3(1, 0, 0), Movements.DirectionL);
    }
    [Test]
    public void Right()
    {
        Assert.AreEqual(new Vector3(-1, 0, 0), Movements.DirectionR);
    }
    [Test]
    public void Jump()
    {
        Assert.AreEqual(new Vector3(0, 1, 0), Movements.Jump);
    }
    [Test]
    public void Walk()
    {
        float walkSpeed = 0.5f;
        Assert.AreEqual(walkSpeed, Movements.Walk);
    }
    [Test]
    public void Sprint()
    {
        float sprintSpeed = 4f;
        Assert.AreEqual(sprintSpeed, Movements.Sprint);
    }
}
