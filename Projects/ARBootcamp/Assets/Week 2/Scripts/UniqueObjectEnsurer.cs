using UnityEngine;
public class UniqueObjectEnsurer : MonoBehaviour
{
    private void Awake()
    {
        foreach (var sameObject in FindObjectsOfType<UniqueObjectEnsurer>())
        {
            if (sameObject != this)
            {
                // you might want to do stuff here, like deleting existing reference points, before destroying
                Destroy(sameObject);
            }
        }
    }
}