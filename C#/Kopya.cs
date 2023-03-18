using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kopya : MonoBehaviour
{
    public int kopya = 0;
    public GameObject Top;
    public Transform cikis;

    void OnTriggerEnter(Collider nesne)
    {
        if (nesne.gameObject.tag == "Top")
        {
            for (int i = 0; i < kopya; i++)
            {
                GameObject yeniTop = Instantiate(Top, cikis.position, Quaternion.identity);
            }
            Destroy(nesne.gameObject);
        }
    }
}
