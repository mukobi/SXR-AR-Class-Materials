using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Adds each of the scenes from your build settings as buttons under a certain game object.
/// </summary>
public class AddSceneButtons : MonoBehaviour
{
    [SerializeField] private Transform buttonParent;
    [SerializeField] private GameObject buttonPrefab;

    private void Start()
    {
        // Start at 1 to skip main menu scene
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            GameObject buttonObject = Instantiate(buttonPrefab);
            buttonObject.transform.SetParent(buttonParent);

            Scene scene = SceneManager.GetSceneByBuildIndex(i);

            string sceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            buttonObject.GetComponentInChildren<TextMeshProUGUI>().SetText(sceneName);
            buttonObject.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(sceneName) );
        }
    }

}
