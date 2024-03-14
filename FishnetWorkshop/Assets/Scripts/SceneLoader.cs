using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string serverScene1Name;
    [SerializeField] string clientscene1Name;
    
    void Start()
    {
        if(Application.platform is RuntimePlatform.WindowsServer or RuntimePlatform.OSXServer or RuntimePlatform.LinuxServer){
            SceneManager.LoadScene(serverScene1Name);
        } else{
            SceneManager.LoadScene(clientscene1Name);
        }
    }
}
