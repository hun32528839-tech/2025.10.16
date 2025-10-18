using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{ 
    public void OnClickRetry()
    {
        gameObject.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage1");
    }
}

