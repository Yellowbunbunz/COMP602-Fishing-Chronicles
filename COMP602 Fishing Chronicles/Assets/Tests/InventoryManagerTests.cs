using NUnit.Framework;
using UnityEngine;

public class InventoryManagerTests
{
    private InventoryManagerTest inventoryManager;

    [SetUp]
    public void Setup()
    {
        // Create an instance of the InventoryManager
        inventoryManager = new GameObject().AddComponent<InventoryManagerTest>();
    }

    [TearDown]
    public void Teardown()
    {
        // Clean up after the test
        Object.DestroyImmediate(inventoryManager.gameObject);
    }

    [Test]
    public void AddItemToInventory()
    {
        // Arrange
        ItemsTest item = ScriptableObject.CreateInstance<ItemsTest>();
        item.ID = 1;
        item.itemName = "Test Item";
        item.value = 10;
        item.icon = null;

        // Act
        inventoryManager.Add(item);

        // Assert
        Assert.IsTrue(inventoryManager.Contains(item));
        Assert.AreEqual(1, inventoryManager.GetInventorySize());
    }

    [Test]
    public void CheckIfItemExistsInInventory()
    {
        // Arrange
        ItemsTest item1 = ScriptableObject.CreateInstance<ItemsTest>();
        ItemsTest item2 = ScriptableObject.CreateInstance<ItemsTest>();

        // Add item1 to the inventory
        inventoryManager.Add(item1);

        // Act & Assert
        Assert.IsTrue(inventoryManager.Contains(item1));
        Assert.IsFalse(inventoryManager.Contains(item2));
    }

    [Test]
    public void GetInventorySize()
    {
        // Arrange
        ItemsTest item1 = ScriptableObject.CreateInstance<ItemsTest>();
        ItemsTest item2 = ScriptableObject.CreateInstance<ItemsTest>();

        // Add two items to the inventory
        inventoryManager.Add(item1);
        inventoryManager.Add(item2);

        // Act & Assert
        Assert.AreEqual(2, inventoryManager.GetInventorySize());
    }
}
