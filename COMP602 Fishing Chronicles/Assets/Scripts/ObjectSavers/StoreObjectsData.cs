using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreObjectsData : MonoBehaviour
{
    private static StoreObjectsData _instance;//this makes a single instance
    private string startScene;

    private void Awake()
    {
        //makes sure there isn't another instance of the same object however this is now causing an issue
        //as I can't have multiple objects using this one code, will need to find a solution
        //APPENDAGE: Current solution is to add to an empty object holding multiple objects inside
        //this is a temporary solution, I believe logically there must be a better way since I can't imagine
        //holding 100+ objects to be the best solution
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);//saves to "don't destroy on load heirarchy
        }
        else
        {
            Destroy(this.gameObject);//destroys the object if not null
            return;
        }
        SceneManager.sceneLoaded += OnSceneLoaded;//loads a function
    }

    //this function is called in the onAwake which happens each time a scene is started. Unlike onStart.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //this is used to see what scene we are currently in to help with the if later
        if (startScene == null)
        {
            startScene = SceneManager.GetActiveScene().name;
        }
        //prevented unity saying there is an error, as the function would be called with a destroyed
        //gameObject, fixed by using this if
        if (_instance != null)
        {
            // Check if the loaded scene is the original loaded scene
            //if this method was fully working, this will basically take in the scene the block is spawned in
            //and always check if the scene currently in, is the scene it was spawned in, if so, block is enabled
            //otherwise block disabled
            if (scene.name == startScene)
            {
                this.gameObject.SetActive(true);
            }
            if (scene.name != startScene)
            {
                this.gameObject.SetActive(false);
            }
        }

    }

}
