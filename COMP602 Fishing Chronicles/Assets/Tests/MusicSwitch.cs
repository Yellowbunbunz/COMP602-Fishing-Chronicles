using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MusicSwitch
{
    // A Test behaves as an ordinary method
    [Test]
    public void ItemAdded()
    {
        Assert.AreEqual(new Vector3(0, 0, 1), Movements.DirectionF);
    }
    [Test]
    public void ItemRemoved()
    {
        Assert.AreEqual(new Vector3(0, 0, 1), Movements.DirectionF);
    }
    [Test]
    public void ItemSold()
    {
        Assert.AreEqual(new Vector3(0, 0, 1), Movements.DirectionF);
    }
    [Test]
    public void ItemBought()
    {
        Assert.AreEqual(new Vector3(0, 0, 1), Movements.DirectionF);
    }
}
