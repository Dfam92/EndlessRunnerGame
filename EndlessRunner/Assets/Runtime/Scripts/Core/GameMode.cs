using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    [SerializeField] private float reloadGameDelay = 3;
    [SerializeField] private PlayerController player;
    [SerializeField] private TextMeshProUGUI travelledDistance;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI countDownText;
    [SerializeField] float timeToCountDown;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject MainHud;
    [SerializeField] private GameObject PauseHud;
    [SerializeField] private GameObject StartHud;
    private bool startGame;
    public void OnGameOver()
    {
        StartCoroutine(ReloadGameCoroutine());
    }
    private void Update()
    {
        travelledDistance.text = player.TravelledDistance + "M";
        scoreText.text ="Score: " + player.Score;
        CountDown();
    }
    public void StartGame()
    {
        startGame = true;
        StartCoroutine(StartGameCountDown());
        StartHud.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseHud.SetActive(true);
        MainHud.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseHud.SetActive(false);
        MainHud.SetActive(true);
    }

    private void CountDown()
    {
        if (timeToCountDown > 0 && startGame)
        {
            countDownText.enabled = true;
            timeToCountDown -= 1 * Time.deltaTime;
            countDownText.text = $"{Mathf.Round(timeToCountDown)}";
        }
        else
        {
            countDownText.enabled = false;
        }
    }
    private IEnumerator ReloadGameCoroutine()
    {
        //esperar uma frame
        yield return new WaitForSeconds(reloadGameDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private IEnumerator StartGameCountDown()
    {
        yield return new WaitForSeconds(timeToCountDown);
        playerAnimator.SetTrigger(PlayerAnimationConstants.StartGameTrigger);
        MainHud.SetActive(true);
    }

}
