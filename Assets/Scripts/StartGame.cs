using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//using "Enemy.cs";
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public const int NUMBER_OF_ENEMIES = 55;

    public string filename;

    public Enemy enemy1;
    public Enemy enemy2;
    public Enemy enemy3;
    public Enemy enemy4;
    public GameObject barricade;

    public GameObject Player; 

    public Transform parentTransform;

    private Enemy[] enemies = new Enemy[NUMBER_OF_ENEMIES];
    private int enemyNumber = 0;
    private int currentEnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("It's a-me, the level starter");
        RefreshParse();
        currentEnemyCount = NUMBER_OF_ENEMIES;
    }

    /*
     * This imitates the original game's timing of
     * updating the enemies.  The more enemies, the slower
     * they move.  Updating 14 enemies once takes as much
     * time as updating one enemy 14 times
     */
    void Update()
    {
        new WaitForSeconds(0.1f);

        if (enemyNumber >= enemies.Length)
        {
            enemyNumber = 0;
        }

        //make it move
        if (enemies[enemyNumber] != null) {
            (enemies[enemyNumber]).Move();
        }

        //find the next enemy
        do {
            enemyNumber++;
            if (enemyNumber >= enemies.Length)
            {
                enemyNumber = 0;
            }
        } while (enemies[enemyNumber] == null);
    }

    private void FileParser()
    {
        enemyNumber = 0;

        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;
            int column;

            while ((line = sr.ReadLine()) != null)
            {
                column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    //Call SpawnPrefab
                    SpawnPrefab(letter, new Vector3(column++, -1 * row, 0));
                    //Debug.Log("Spawned an item at " + column + ", " + row);
                }
                row++;
            }

            enemies[49].gunship = true;
            //enemies[49].shottingOffset = new Transform()

            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        Enemy ToSpawn;

        switch (spot)
        {
            case 'a':
                ToSpawn = enemy4;
                //enemies[enemyNumber] = enemy;
                enemies[enemyNumber] = GameObject.Instantiate(ToSpawn, parentTransform);
                enemies[enemyNumber++].transform.localPosition = positionToSpawn;
                //enemies[numberOfEnemies++] = ToSpawn;
                return;
            case 'b':
                ToSpawn = enemy3;
                //enemies[enemyNumber] = enemy;
                enemies[enemyNumber] = GameObject.Instantiate(ToSpawn, parentTransform);
                enemies[enemyNumber++].transform.localPosition = positionToSpawn;
                //enemies[numberOfEnemies++] = ToSpawn;
                return;
            case 'c':
                ToSpawn = enemy2;
                //enemies[enemyNumber] = enemy;
                enemies[enemyNumber] = GameObject.Instantiate(ToSpawn, parentTransform);
                enemies[enemyNumber++].transform.localPosition = positionToSpawn;
                //enemies[numberOfEnemies++] = ToSpawn;
                return;
            case 'd':
                ToSpawn = enemy1;
                //enemies[enemyNumber] = enemy;
                enemies[enemyNumber] = GameObject.Instantiate(ToSpawn, parentTransform);
                enemies[enemyNumber++].transform.localPosition = positionToSpawn;
                //enemies[numberOfEnemies++] = ToSpawn;
                return;
            case 's':
                GameObject hi = barricade;
                //enemies[enemyNumber] = enemy;
                hi = GameObject.Instantiate(hi, parentTransform);
                hi.transform.localPosition = positionToSpawn;
                //enemies[numberOfEnemies++] = ToSpawn;
                return;
            default: return;
                //ToSpawn = //Brick;       break;
        }
    }

    public void RefreshParse()
    {
        GameObject newParent = GameObject.Find("Level");
        //newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;

        //if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();   
        //SpawnPrefab(letter, new Vector3(column++, -row, 0));
    }

    public void LowerAllEnemies()
    {
        foreach(Enemy i in enemies) {
            if(i != null)
                i.down();
        }
    }
    public void decrementEnemies() {
        //currentEnemyCount--;
        if (--currentEnemyCount == 0) { //game ends in a win
            SceneManager.LoadScene("Credits");
            currentEnemyCount = NUMBER_OF_ENEMIES;
            /*RefreshParse();
            GameObject.Find("UI").GetComponent<UIScript>().resetGame();*/
            GetComponent<WaitFiveSeconds>().updateScore(GetComponent<UIScript>().getScore());
        }
        //Debug.Log(currentEnemyCount);
    }
}
