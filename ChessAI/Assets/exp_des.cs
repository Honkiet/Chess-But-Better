using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp_des : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
