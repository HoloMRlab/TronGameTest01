using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    public GameControl gameControl;
    public GameObject lightWall;
    private Collider wall;
    private Vector3 lastWallEnd;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameControl.isStart == true)
        {
            SpawnWall();
        }
    }

    public void SpinCycle()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SpawnWall();

            transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SpawnWall();

            transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Wall") || collision.gameObject.tag.Equals("Light"))
        {
            gameControl.isRunning = false;
            Debug.Log("게임오버2");
        }
    }

    private void SpawnWall()
    {
        GameObject point = (GameObject)Instantiate(lightWall, transform.position, Quaternion.identity);
        wall = point.GetComponent<Collider>();
        lastWallEnd = transform.position;
    }

    private void FitColliderBetween(Collider co, Vector3 a, Vector3 b)
    {
        co.transform.position = a + (b - a) * 0.5f;

        float dist = Vector3.Distance(a, b);
        if (a.z != b.z)
        {
            co.transform.localScale = new Vector3(1.0f, 0, dist + 1.0f);
        }
        else if (a.x != b.x)
        {
            co.transform.localScale = new Vector3(dist + 1.0f, 0.0f, 1.0f);
        }
    }

    public void RightTurn()
    {
        SpawnWall();

        transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
    }

    public void LeftTurn()
    {
        SpawnWall();

        transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
    }
}