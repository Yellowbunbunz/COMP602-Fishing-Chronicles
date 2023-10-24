using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterFishingGame : MonoBehaviour
{
    bool fish = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Dock")
        {
            fish = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Dock")
        {
            fish = false;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && fish)
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("FishingScene");//loads the scene
        }
    }
}
