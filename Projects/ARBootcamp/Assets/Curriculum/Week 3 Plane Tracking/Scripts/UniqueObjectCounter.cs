using UnityEngine;

public class UniqueObjectCounter : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log($"Found {FindObjectsOfType<UniqueObjectCounter>().Length} instances of myself on object {gameObject.name}");
    }
}