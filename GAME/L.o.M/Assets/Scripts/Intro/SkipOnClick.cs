using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipOnClick : MonoBehaviour
{
    public UnityEngine.Video.VideoClip videoClip;
    // Start is called before the first frame update
    void Start()
    {
        var videoPlayer = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = true;
    }

    // Update is called once per frame
    void Update()
    {

        var vp = GetComponent<UnityEngine.Video.VideoPlayer>();
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainLevel");
        }

        if (vp.isPlaying == false)
        {
            SceneManager.LoadScene("MainLevel");
        }
    }
}
