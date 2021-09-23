using UnityEngine;

public class StartMenu : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
