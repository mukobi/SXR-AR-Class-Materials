using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    private void Update()
    {
        // Handle Android back button (read as Esc)
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GoBackToMenu();
            }
        }
    }

    public void GoBackToMenu()
    {
        string menuName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(0));
        SceneManager.LoadScene(menuName);
    }
}
