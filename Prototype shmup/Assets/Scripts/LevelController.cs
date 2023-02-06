using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    //Instance
    public static LevelController instance;

    //Values
    uint numEnemies = 0;
    bool startNextLevel = false;
    float nextLevelTimer = 3;

    //Levels
    string[] levels = { "level 1", "Level 2" };
    int currentLevel = 1;

    //UI
    public int score;
    Text P1Score;

    //Awake
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            P1Score = 
                GameObject.Find("P1 Score").GetComponent<Text>();

        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startNextLevel)
        {
            if (nextLevelTimer <= 0)
            {
                currentLevel++;
                if (currentLevel <= levels.Length)
                {
                    string sceneName = levels[currentLevel - 1];
                    SceneManager.LoadSceneAsync(sceneName);
                }
                else
                {
                    Debug.Log("GAME OVER!!!");
                }
                nextLevelTimer = 3;
                startNextLevel = false;

            }
            else
            {
                nextLevelTimer -= Time.deltaTime;
            }

        }

    }

    public void AddScore(int amountToAdd)
    {
        score += amountToAdd;
        P1Score.text = ("Score: ") + score.ToString();
    }

    public void AddEnemy()
    {
        numEnemies++;
    }

    public void RemoveEnemy()
    {
        numEnemies--;

        if (numEnemies == 0)
        {
            startNextLevel = true;
        }

    }

}
