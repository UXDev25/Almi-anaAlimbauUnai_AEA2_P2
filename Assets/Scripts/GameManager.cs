using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerController MainPlayer { get; private set; }

    [Header("Game settings")]
    [SerializeField] private int startingLives = 3;
    [SerializeField] private GameObject eventSystem;
    public bool HasLoadedScene { get; set; }

    [Header("Scene Names")]
    public string playScene = "AsteroidsEscene";
    public string menuScene = "MainMenu";

    [Header("UI (Phase 7)")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private GameObject gameOverPanel;


    [Header("Game tags")]
    public string PlayerTag = "Player";
	public string AsteroidTag = "Asteroid";
	public string BulletTag = "Bullet";

	private int score;
    private int lives;

    // fem això perquè els altres scripts només o puguin llegir però no modificar aquest valor.
    public bool IsGameOver { get; private set; }

    private void Awake()
    {
		// TODO: Singleton (igual que amb les pools).
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		//DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        // TODO: inicialitza el joc.
        MainPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (MainPlayer == null) throw new MissingReferenceException("Player not detected on scene!"); // Comprobem que el player hi sigui a l'escena
        lives = startingLives;
        score = 0;
        UpdateUI();

    }

    // Cridat pel Asteroid quan aquest és destruït.
    public void AddScore(int points)
    {
        // TODO: afegeix punts a la UI i actualitza-la.
        score += points;
        UpdateUI();
    }

    // Cridat pel Ateroid quan impacta amb el player.
    public void LoseLife(int amount)
    {
        // TODO: Resta amount a lives i actualitza la UI.
        lives -= amount;
        UpdateUI();
        if (lives <= 0) GameOver();
    }

    private void GameOver()
    {
        // TODO:
        IsGameOver = true;
		Time.timeScale = 0;
		//     Fes aparèixer el panell de GameOver
        gameOverPanel.SetActive(true);

	}

    // Assigna aquest mètode al Restart button: On Click () al Inspector.
    public void RestartGame()
    {
        // TODO:
        Time.timeScale = 1;
        score = 0;
        lives = startingLives;
		gameOverPanel.SetActive(false);
        //     fes un reload de l'escena:
        Debug.Log(Time.timeScale);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    private void UpdateUI()
    {
        scoreText.text = $"{score}";
        livesText.text = $"{lives}";
    }

    // --Scene Management--
    public void SetLoadedAndTime(bool hasLoaded, float time, string sceneName)
    {
        Time.timeScale = time;
        Instance.HasLoadedScene = hasLoaded;
        transform.GetChild(0).gameObject.SetActive(true);
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
