using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    private void Update()
    {
        // Handle Android back (read as Esc) or menu button
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Menu))
            {
                GoBackToMenu();
            }
        }
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
