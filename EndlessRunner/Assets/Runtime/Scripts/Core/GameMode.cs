using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    [SerializeField] private float baseScoreMultiplier = 1;
    private float score;
    public int Score => Mathf.RoundToInt(score);

    [SerializeField] PlayerController player;
    [SerializeField] PlayerAnimationController playerAnimationController;

    [SerializeField] private MainHUD mainHud;

    [SerializeField] private MusicPlayer musicPlayer;
    [SerializeField] private float reloadGameDelay = 3;


    [SerializeField]
    [Range(0, 5)]
    private int startGameCountdown = 5;
    private bool startGame;
    private void Awake()
    {
        SetWaitForStartGameState();
    }
    private void Update()
    {
        UpdateScore();
    }
    private void SetWaitForStartGameState()
    {
        player.enabled = false;
        mainHud.ShowStartGameOverlay();
        musicPlayer.PlayStartMenuMusic();
    }

    public void OnGameOver()
    {
        StartCoroutine(ReloadGameCoroutine());
        
    }

    private IEnumerator ReloadGameCoroutine()
    {
        yield return new WaitForSeconds(1);
        musicPlayer.PlayGameOverMusic();
        yield return new WaitForSeconds(reloadGameDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        StartCoroutine(StartGameCor());
       
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private void UpdateScore()
    {
        if(startGame)
        {
            score += baseScoreMultiplier * player.ForwardSpeed * Time.deltaTime;
        }
    }
        
   
    private IEnumerator StartGameCor()
    {
        musicPlayer.PlayMainTrackMusic();
        yield return StartCoroutine(mainHud.PlayStartGameCountdown(startGameCountdown));
        playerAnimationController.PlayStartGameAnimation();
        startGame = true;
        player.enabled = true;
    }
}
