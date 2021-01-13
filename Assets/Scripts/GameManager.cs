using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject homeMenu;
    public GameObject gameOverMenu;
    public GameObject congratsMenu;

    public float speed = 2;
    public Renderer bg;
    public GameObject col;
    public GameObject rock1;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject rock2;
    public GameObject queen;
    public bool gameOver = false;
    public bool congrats = false;
    public List<GameObject> cols;
    public List<GameObject> enemies;
    public List<GameObject> queens;
    public bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        // Create Map
        for (int i = 0; i < 21; i++)
        {
            cols.Add(Instantiate(col, new Vector2(-10 + i, -3), Quaternion.identity));
        }

        float rPosition = Random.Range(20, 100);
        queens.Add(Instantiate(queen, new Vector2(rPosition, -2), Quaternion.identity));

        // Create enemies
        enemies.Add(Instantiate(enemy1, new Vector2(14, -2.2f), Quaternion.identity));
        enemies.Add(Instantiate(enemy2, new Vector2(18, -2.2f), Quaternion.identity));
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
        if (start == true && gameOver == true && congrats == false)
        {
            gameOverMenu.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start == true && congrats == true && gameOver == false)
        {
            congratsMenu.SetActive(true);
            gameOverMenu.SetActive(false);
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

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].transform.position.x <= -10)
                {
                    float rObstacle = Random.Range(11, 18);
                    enemies[i].transform.position = new Vector3(rObstacle, -2.2f, 0);
                }
                enemies[i].transform.position = enemies[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }

            for (int i = 0; i < queens.Count; i++)
            {
                if (queens[i].transform.position.x <= -10)
                {
                    float rObstacle = Random.Range(11, 18);
                    queens[i].transform.position = new Vector3(rObstacle, -2.2f, 0);
                }
                queens[i].transform.position = queens[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }
        }

    }
}
