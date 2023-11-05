using UnityEngine;

namespace Task1.PlayerCamera
{
    public class CameraFollowPlayer : MonoBehaviour
    {
        [SerializeField] Transform cameraPosition;

        void Update()
        {
            transform.position = cameraPosition.position;
            transform.rotation = cameraPosition.rotation;
        }
    }
}

