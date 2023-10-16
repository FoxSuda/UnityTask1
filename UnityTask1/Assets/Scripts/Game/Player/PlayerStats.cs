using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private PlayerMovement playerMovement;

    [Header("Player movement")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 8f;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerMovement.moveSpeed = moveSpeed;
        playerMovement.jumpForce = jumpForce;
    }

    private void Update()
    {
        if (playerMovement.moveSpeed != moveSpeed)
        {
            playerMovement.moveSpeed = moveSpeed;
        }
        if (playerMovement.jumpForce != jumpForce)
        {
            playerMovement.jumpForce = jumpForce;
        }
    }

}
