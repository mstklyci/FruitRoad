using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GravityController : MonoBehaviour
{
    public GameObject Top;
    public GameObject TopClone;
    void Start()
    {
        Physics.gravity = new Vector3(0, -10, 0);
    }

    public void gravityspace()
    {
        Physics.gravity = new Vector3(0, +10, 0);
    }
    public void gravity()
    {
        Physics.gravity = new Vector3(0, -10, 0);
    }
}