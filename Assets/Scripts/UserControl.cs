using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserControl : MonoBehaviour
{
    public Transform player;
    public Text gameOver;
    public float speed;
    public bool isRunning;

    private Transform user;

    private void Start()
    {
        isRunning = true;
    }

    private void Update()
    {
        if (isRunning)
        {
            player.transform.Translate(0.0f, 0.0f, speed);
        }
        else
        {
            player.transform.Translate(0.0f, 0.0f, 0.0f);
        }
    }
}