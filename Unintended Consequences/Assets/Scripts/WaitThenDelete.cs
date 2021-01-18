using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitThenDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(waitAndDelete());
    }

    IEnumerator waitAndDelete()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }

}
