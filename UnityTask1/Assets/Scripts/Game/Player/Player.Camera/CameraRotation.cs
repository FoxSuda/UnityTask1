using UnityEngine;

namespace Task1.PlayerCamera
{
    public class CameraRotation : MonoBehaviour
    {
        [SerializeField] private float sensX;
        [SerializeField] private float sensY;

        [SerializeField] private Transform orientation;

        private float xRotation;
        private float yRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if (Time.timeScale != 0f)
            {
                float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
                float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;

                yRotation += mouseX;

                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -150f, 0f);

                transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
                orientation.rotation = Quaternion.Euler(0, yRotation, 0);
            }
        }
    }
}

