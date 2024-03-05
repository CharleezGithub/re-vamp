using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutSceneManagerMP4 : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    void Start()
    {
        // Set up VideoPlayer
        videoPlayer.loopPointReached += EndReached;

        // Play video
        videoPlayer.Play();
    }

    void EndReached(VideoPlayer vp)
    {
        // Video has ended, transition to the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
