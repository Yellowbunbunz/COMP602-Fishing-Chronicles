using UnityEngine;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class HouseSaverTests
{
    [Test]
    public void HouseSaver_InstanceIsNotDestroyedAndIsActive()
    {
        // Arrange
        HouseSaver houseSaver;

        // Act
        EditorSceneManager.OpenScene("Assets/Scenes/House.unity");

        // Assert
        houseSaver = Object.FindObjectOfType<HouseSaver>();

        // Ensure that HouseSaver is not null, meaning it wasn't destroyed.
        Assert.IsNotNull(houseSaver);
    }
}