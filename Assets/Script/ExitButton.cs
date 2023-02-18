using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
