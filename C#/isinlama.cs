using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isinlama : MonoBehaviour
{
    
    public GameObject Top;
    public Transform isinlamacikis;
    void OnTriggerEnter(Collider nesne)
    {
        if (nesne.gameObject.tag == "Top")
        {           
                Instantiate(Top, isinlamacikis.transform.position = isinlamacikis.position, Quaternion.identity);
        }
    }
}