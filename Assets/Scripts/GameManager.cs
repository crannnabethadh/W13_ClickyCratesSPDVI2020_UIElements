using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Unity.UIElements.Runtime;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
//    public TextMeshProUGUI scoreText;
//    public TextMeshProUGUI gameOverText;
//    public Button restartButton;
    //public GameObject titleScreen;
    public bool isGameActive;


    // UI Panel Renderers
    // Note: normally you can just use one Panel Rendere and just hide or swap in/out
    // (using ve.style.display) elements at runtime. It's a lot more efficient
    // to use a single PanelRenderer.
    //public PanelRenderer m_MainMenuScreen;
    public PanelRenderer m_GameScreen;  // Important! Remember to Enable live updates!!!!
    //public PanelRenderer m_EndScreen;

    // Pre-loaded UI assets (ie. UXML/USS).
    //public VisualTreeAsset m_GameScreenTreeAsset;
    //public StyleSheet m_PlayerListItemStyles;

    // The Panel Renderer can optionally track assets to enable live
    // updates to any changes made in the UI Builder for specific UI
    // assets (ie. UXML/USS).
    //private List<Object> m_TrackedAssetsForLiveUpdates;

    // We need to update the values of some UI elements so here are
    // their remembered references after being queried from the cloned
    // UXML.
    private Label m_ScoreLabel;


    // OnEnable
    // Register our postUxmlReload callbacks to be notified if and when
    // the UXML or USS assets being user are changed (by the UI Builder).
    // In these callbacks, we just rebind UI VisualElements to data or
    // to click events.
    private void OnEnable()
    {
        m_GameScreen.postUxmlReload = BindGameScreen;  // Important!!!
        //m_TrackedAssetsForLiveUpdates = new List<Object>();
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    // Bind UI to logic

    // Try to find specific elements by name in the main menu screen and
    // bind them to callbacks and data. Not finding an element is a valid
    // state.

    private IEnumerable<Object> BindGameScreen()
    {
        
        var root = m_GameScreen.visualTree;
        m_ScoreLabel = root.Query<Label>("_score");  // name of the element in UXML
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame(1);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        //titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, 4);
            Instantiate(targets[randomIndex]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        m_ScoreLabel.text = "Score: " + score;
    }

    public void GameOver()
    {
        //gameOverText.gameObject.SetActive(true);
        //restartButton.gameObject.SetActive(true);
        //Time.timeScale = 0;
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
