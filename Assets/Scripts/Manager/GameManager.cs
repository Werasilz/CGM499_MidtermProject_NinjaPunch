using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool isStartGame;
    public int enemyAmount;
    public int currentEnemyAmount;
    public int playerHealth;

    public GameObject enemyPrefab;
    public Transform spawnPositionLeft;
    public Transform spawnPositionRight;
    public GameObject redScreen;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI enemyCountText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI readyText;
    public TextMeshProUGUI startText;

    private EnemyObjectPool _pool;

    private void Start()
    {
        _pool = gameObject.AddComponent<EnemyObjectPool>();
        _pool.enemyPrefab = enemyPrefab;

        currentEnemyAmount = enemyAmount;
    }

    public void StartGame()
    {
        isStartGame = true;
        _pool.Spawn();
        StartCoroutine(StartText());
        Debug.Log("Start Game");
    }

    IEnumerator StartText()
    {
        readyText.gameObject.SetActive(false);
        startText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        startText.gameObject.SetActive(false);
    }

    public void PlayerTakeDamage(int damage)
    {
        playerHealth -= damage;
    }

    private void Update()
    {
        hpText.text = "HP : " + playerHealth;
        enemyCountText.text = "ENEMY LEFT : " + currentEnemyAmount;

        if (currentEnemyAmount <= 0)
        {
            winText.gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        EventManager.RestartEvent += ResetGameManager;
        EventManager.HPFullEvent += HealthFull;
    }

    private void OnDisable()
    {
        EventManager.RestartEvent -= ResetGameManager;
        EventManager.HPFullEvent -= HealthFull;
    }

    private void ResetGameManager()
    {
        // isStartGame = false;
        // enemyAmount = 50;
        // currentEnemyAmount = 0;
        // playerHealth = 5;
        // currentEnemyAmount = enemyAmount;

        // hpText.text = "HP : " + playerHealth;
        // enemyCountText.text = "ENEMY LEFT : " + currentEnemyAmount;

        // winText.gameObject.SetActive(false);
        // gameOverText.gameObject.SetActive(false);

        Destroy(gameObject);
        Destroy(ScreenShake.Instance.gameObject);
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex);
    }

    private void HealthFull()
    {
        playerHealth = 5;
    }
}
