using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    //speed control
    public static float Sprint = 4f;
    public static float Walk = 0.5f;

    //Direction control
    public static Vector3 DirectionF = new Vector3(0, 0, 1);
    public static Vector3 DirectionB = new Vector3(0, 0, -1);
    public static Vector3 DirectionL = new Vector3(1, 0, 0);
    public static Vector3 DirectionR = new Vector3(-1, 0, 0);
    public static Vector3 Jump = new Vector3(0, 1, 0);

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
