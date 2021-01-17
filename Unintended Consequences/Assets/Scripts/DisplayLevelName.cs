using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;
public class DisplayLevelName : NetworkBehaviour
{
    [SyncVar]
    string sceneName;
    Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
        sceneName = SceneManager.GetActiveScene().name;
        myText.text = sceneName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
