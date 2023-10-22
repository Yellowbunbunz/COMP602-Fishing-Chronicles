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
        //testing walking forward backward and such
        Assert.AreEqual(new Vector3(0, 0, 1), Movements.DirectionF);
        Assert.AreEqual(new Vector3(0, 0, -1), Movements.DirectionB);
        Assert.AreEqual(new Vector3(1, 0, 0), Movements.DirectionL);
        Assert.AreEqual(new Vector3(-1, 0, 0), Movements.DirectionR);
    }
    [Test]
    public void Complex()
    {
        //testing the ability to sprint walk and jump
        float walkSpeed = 0.5f;
        float sprintSpeed = 4f;
        Assert.AreEqual(new Vector3(0, 1, 0), Movements.Jump);
        Assert.AreEqual(walkSpeed, Movements.Walk);
        Assert.AreEqual(sprintSpeed, Movements.Sprint);
    }
}
