using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _exitGameChannel = default;
    
    private void OnEnable()
    {
        if (_exitGameChannel != null)
        {
            _exitGameChannel.OnEventRaised += ExitGame;
        }
    }

    private void OnDisable()
    {
        if (_exitGameChannel != null)
        {
            _exitGameChannel.OnEventRaised -= ExitGame;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
