using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaslangicEngel : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Collider>().enabled = true;
        StartCoroutine(DisableColliderForSeconds(10f));
    }

    IEnumerator DisableColliderForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        GetComponent<Collider>().enabled = false;
    }
}
