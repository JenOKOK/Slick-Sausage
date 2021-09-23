using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private GameObject _FallScreen;

    private Button _buttonRestart;

    private void Awake()
    { 
       _buttonRestart = _FallScreen.GetComponentInChildren<Button>();
    }

    private void OnEnable()
    {
        _buttonRestart.onClick.AddListener(ReloadLevel);
    }
    private void OnDisable()
    {
        _buttonRestart.onClick.RemoveListener(ReloadLevel);
    }

    private void OnTriggerEnter(Collider other)
    {
        if  (other.TryGetComponent(out Rigidbody sausage))
        {
            _FallScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void ReloadLevel()
    {
        Time.timeScale = 1f;
        _FallScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
