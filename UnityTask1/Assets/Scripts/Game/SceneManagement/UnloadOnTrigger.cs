using Task1.Player;
using UnityEngine;

public class UnloadOnTrigger : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("Unloading Scene " + gameObject.name + " collision!");
            sceneController.UnloadScene(gameObject.name);
        }
    }
}
