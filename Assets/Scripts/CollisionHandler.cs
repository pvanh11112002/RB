using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    int currentScene = 0;
    [SerializeField] float delayTimeBeforeLoadSequence = 2f;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log(1);
                break;
            case "Finish":
                StartFinishSequence();
                break;
            case "Fuel":
                Debug.Log(3);
                break;
            default:
                StartCrashSequence();
                break;

        }    
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(currentScene);
    }
    private void LoadNextLevel()
    {
        
        currentScene++;
        if (currentScene >= SceneManager.sceneCountInBuildSettings)
        {
            currentScene = 0;
        }
        SceneManager.LoadScene(currentScene);
    }
    private void StartCrashSequence()
    {
        GetComponent<PlayerMovementHandle>().enabled = false;
        Invoke("ReloadLevel", delayTimeBeforeLoadSequence);
    }
    private void StartFinishSequence()
    {
        GetComponent<PlayerMovementHandle>().enabled = false;
        Invoke("LoadNextLevel", delayTimeBeforeLoadSequence);
    }
}
