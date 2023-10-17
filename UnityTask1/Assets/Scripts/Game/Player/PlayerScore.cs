using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    [SerializeField] private int scoreMultiply = 1;

    private int scoreCount = 0;

    public void AddScore()
    {
        Debug.Log("3434343");
        scoreCount = scoreCount + scoreMultiply;
        scoreText.text = "" + scoreCount;
    }
}
