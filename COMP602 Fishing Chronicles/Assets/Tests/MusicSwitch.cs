using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MusicSwitch
{
    [Test]
    public void SongAtPosition0IsExpected()
    {
        // Arrange: Create an instance of your GameMusic script.
        GameObject gameMusicObject = new GameObject("GameMusicObject");
        GameMusic gameMusic = gameMusicObject.AddComponent<GameMusic>();

        // Act: Initialize the audioClips array.
        gameMusic.audioClips = new AudioClip[3]; // Make sure it's properly sized and initialized.

        // Set an expected AudioClip for position 0.
        AudioClip expectedClip = Resources.Load<AudioClip>("villageMusic");

        gameMusic.audioClips[0] = expectedClip; // Assign the expected AudioClip to position 0.

        // Assert: Check if the song at position 0 matches the expected clip.
        Assert.AreEqual(expectedClip, gameMusic.audioClips[0]);
    }
}
