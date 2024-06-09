using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneChanger : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Reference to the VideoPlayer component
    public string nextSceneName;     // Name of the scene to load next

    void Start()
    {
        // Ensure the VideoPlayer component is referenced
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Subscribe to the loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Numlock))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    // Method called when the video ends
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
