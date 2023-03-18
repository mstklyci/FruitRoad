using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public int sahne = 0;
    public void RestartGame()
    {
        SceneManager.LoadScene(sahne); ;
    }
    public void Menudonus()
    {
        SceneManager.LoadScene(0); ;
    }





}
