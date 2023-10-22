using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class RodMovementTests
{
    private RodMovement rodMovement;

    [Test]
    public void WaterObjectExists()
    {
        // Arrange
        RodMovement rodMovement = new RodMovement(); // Instantiate your script

        // Act
        SpriteRenderer waterObject = rodMovement.water;

        // Assert
        Assert.IsNotNull(waterObject, "The water object should not be null.");
    }
}

