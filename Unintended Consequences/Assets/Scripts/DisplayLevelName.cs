using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayLevelName : MonoBehaviour
{
    Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
        myText.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
