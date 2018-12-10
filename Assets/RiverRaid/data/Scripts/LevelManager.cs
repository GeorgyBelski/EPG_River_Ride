using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject player;
    public List<GameObject> levels;
    public GameObject currentLevel;
    public byte levelNumber;
    public float playerLevelPosition;

    private bool isNextLavelLoaded;
    private GameObject loadedLevel;
    private Player playerScript;

    void Start () {
        levelNumber = 1;
        isNextLavelLoaded = false;
        playerLevelPosition = player.transform.position.z;
        playerScript = player.GetComponent<Player>();

    }
	
	void Update ()
    {
        playerLevelPosition = player.transform.position.z % 112;
        if (!isNextLavelLoaded)
        {
            if (playerLevelPosition > 70)
            {
                Debug.Log("Time to upload a next level!");
                GameObject newLevel = levels[levelNumber % levels.Count];
                loadedLevel = Instantiate(newLevel, new Vector3(0,0, 112 * levelNumber), newLevel.transform.rotation);
                isNextLavelLoaded = true;
            }
        }
        else
        {
            if (playerLevelPosition > 5 && playerLevelPosition < 10)
            {
                playerScript.checkPoint = new Vector3(0, 1.1f, player.transform.position.z);
                levelNumber++;
                isNextLavelLoaded = false;
                Destroy(currentLevel);
                currentLevel = loadedLevel;
            }
        }

    }
}
