using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public bool isStart;
    public Transform cycleSource;
    public GameObject gameOver;
    public GameObject intro;
    public FollowCam follows;
    public GameObject miniMap;
    public Button rBtn;
    public Button lBtn;

    public float speed;

    public bool isRunning;
    public Transform lightCycle;

    // Start is called before the first frame update
    private void Start()
    {
        lightCycle = Instantiate(cycleSource, new Vector3(15.0f, 0.0f, 15.0f), Quaternion.identity);
        lightCycle.GetComponent<Cycle>().gameControl = this;
        follows.GetComponent<FollowCam>().target = lightCycle;
        //
        isStart = false;
        // fasle로 고침
        isRunning = false;
        gameOver.gameObject.SetActive(false);
        //
        intro.gameObject.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (isRunning && isStart) //
        {
            rBtn.gameObject.SetActive(true);
            lBtn.gameObject.SetActive(true);
            miniMap.gameObject.SetActive(true);
            lightCycle.Translate(0.0f, 0.0f, speed);
            lightCycle.GetComponent<Cycle>().SpinCycle();
            RightSpin();
            LeftSpin();
        }
        else if (isRunning == false && isStart) //
        {
            lightCycle.Translate(0.0f, 0.0f, 0.0f);
            gameOver.gameObject.SetActive(true);
            rBtn.gameObject.SetActive(false);
            lBtn.gameObject.SetActive(false);
            miniMap.gameObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ReStart();
            }
        }
    }

    //
    public void OnClickStart()
    {
        intro.gameObject.SetActive(false);

        isRunning = true;
        isStart = true;
    }

    public void RightSpin()
    {
        lightCycle.GetComponent<Cycle>().RightTurn();
    }

    public void LeftSpin()
    {
        lightCycle.GetComponent<Cycle>().LeftTurn();
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}