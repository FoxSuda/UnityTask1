using Task1.Player;
using UnityEngine;

public class LoadOnTrigger : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("Loading Scene " + gameObject.name + " collision!");
            sceneController.LoadScene(gameObject.name);
        }
    }
}
