using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kutu : MonoBehaviour
{
    public static bool winlevel;
    public float timer=0;

    public int gerekenAdet = 0; // Kutuda gereken A objesi sayýsý
    private int sayac = 0; // Kutudaki A objelerinin sayýsý


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Top" && sayac < gerekenAdet)
        {
            sayac++; // A objesi kutuya girdiðinde sayaç artýrýlýr
        }
    }
    void Start()
    {
        winlevel = false;   
    }
    void Update()
    {
        if (sayac >= gerekenAdet)
        {
            winlevel = true;
            timer += Time.deltaTime;
            if (timer >3)
            {
                int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
                if (nextLevel == 5)
                {
                    SceneManager.LoadScene(0);
                }
                if (PlayerPrefs.GetInt("ReachedLevel", 1) < nextLevel)
                {
                    PlayerPrefs.SetInt("ReachedLevel", nextLevel);
                }               
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}