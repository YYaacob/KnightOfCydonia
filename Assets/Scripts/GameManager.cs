using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject homeMenu;
    public GameObject gameOverMenu;

    public float speed = 2;
    public Renderer bg;
    public GameObject col;
    public GameObject rock1;
    public GameObject rock2;
    public bool gameOver = false;
    public List<GameObject> cols;
    public List<GameObject> obstacles;
    public bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        // Create Map
        for (int i = 0; i < 21; i++)
        {
            cols.Add(Instantiate(col, new Vector2(-10 + i, -3), Quaternion.identity));
        }

        // Create Obstacles
        obstacles.Add(Instantiate(rock1, new Vector2(14, -2), Quaternion.identity));
        obstacles.Add(Instantiate(rock2, new Vector2(18, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }
        if (start == true && gameOver == true)
        {
            gameOverMenu.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start == true && gameOver == false)
        {
            homeMenu.SetActive(false);

            bg.material.mainTextureOffset = bg.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;
            // Move map
            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].transform.position.x <= -10)
                {
                    cols[i].transform.position = new Vector3(10, -3, 0);
                }
                cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }

            // Move obstacles

            for (int i = 0; i < obstacles.Count; i++)
            {
                if (obstacles[i].transform.position.x <= -10)
                {
                    float rObstacle = Random.Range(11, 18);
                    obstacles[i].transform.position = new Vector3(rObstacle, -2, 0);
                }
                obstacles[i].transform.position = obstacles[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }
        }

    }
}
