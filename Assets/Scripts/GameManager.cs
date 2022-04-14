using System.Collections;
using System.Collections.Generic;
//using Unity.Entities;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    /// <singleton>
    /// 
    private static GameManager m_instance = null;
    public static GameManager instance
    {
        private set { }

        get
        {
            if (!m_instance)
            {
                GameObject gameManager = new GameObject("GameManager");
                GameManager manager = gameManager.AddComponent<GameManager>();
                m_instance = manager;
            }
            return m_instance;
        }
    }
    /// </singleton>

    /// <gamevars>
    /// 
    [SerializeField] GameObject midLine;
    public float xBound = 9.5f;
    public float yBound = 4.75f;
    public float ballSpeed = 4f;
    public float respawnDelay = 2f;

    public int numberOfPlayers = 2;
    public int[] playerScores;

    public TextMeshProUGUI mainText;
    public TextMeshProUGUI[] playerTexts;

    //Entity ballEntityPrefab;
   // EntityManager manager;

    WaitForSeconds oneSecond;
    WaitForSeconds delay;

    /// </gamevars>

    private void Awake()
    {
        /// <singleton>
        /// 
        if (m_instance)
        {
            Destroy(gameObject);
            return;
        }

        m_instance = this;
        DontDestroyOnLoad(gameObject);
        /// </singleton>
    }

    private void Start()
    {
        oneSecond = new WaitForSeconds(1.0f);
        delay = new WaitForSeconds(respawnDelay);

        playerScores = new int[numberOfPlayers];

        mainText.text = "";

        StartCoroutine(CountDownAndSpawnBall());
    }

    public void OnPlayerScore(int playerID)
    {
        midLine.SetActive(false);

        playerScores[(playerID - 1)]++;

        for (int i = 0; i < numberOfPlayers; i++)
            playerTexts[i].text = playerScores[i].ToString();

        StartCoroutine(CountDownAndSpawnBall());
    }

    public IEnumerator CountDownAndSpawnBall()
    {
        mainText.text = "Get Ready";
        yield return delay;

        mainText.text = "3";
        yield return oneSecond;

        mainText.text = "2";
        yield return oneSecond;

        mainText.text = "1";
        yield return oneSecond;

        mainText.text = "";

        midLine.SetActive(true);

        ActivateScores();
        SpawnBall();
    }

    void ActivateScores()
    {
        for (int i = 0; i < numberOfPlayers; i++)
            playerTexts[i].gameObject.SetActive(true);
    }

    void SpawnBall()
    {
        
    }
}
