using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBallHit()
    {
        Debug.Log("Playing sound");
        AudioSource.PlayClipAtPoint(audioClips[0], new Vector3(0f, 0f, 0f));
    }

    public void PlaySplat()
    {
        Debug.Log("Playing splat");
        AudioSource.PlayClipAtPoint(audioClips[1], new Vector3(0f, 0f, 0f));
    }
}
