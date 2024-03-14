using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string serverScene1Name;
    [SerializeField] private string clientScene1Name;
    
    void Start()
    {
        if(Application.platform is RuntimePlatform.WindowsServer or RuntimePlatform.OSXServer or RuntimePlatform.LinuxServer){
            SceneManager.LoadScene(serverScene1Name);
        } else{
            SceneManager.LoadScene(clientScene1Name);
        }
    }
}
