using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int StageBlocksQuantity;
    public int PlayerLives;

    private readonly int MenuBuildSettingsIndex = 0;
    private readonly int FirstStageBuildSettingsIndex = 1;
    private readonly int SecondStageBuildSettingsIndex = 2;
    private readonly int ThirdStageBuildSettingsIndex = 3;
    private readonly int EndGameBuildSettingsIndex = 4;
    private readonly int GameOverBuildSettingsIndex = 5;

    public GameObject Heart1, Heart2, Heart3;

    private GameObject StartGameButton;
    private GameObject ExitGameButton;

    public AudioSource BlockSound;

    void Start()
    {
        PlayerLives = PlayerPrefs.GetInt("PlayerLives");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMainMenu();
        }

        CheckPlayerLives();
    }

    public void CheckPlayerLives()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 4)
        {
            switch (PlayerLives)
            {
                case 3:
                    Heart1.SetActive(true);
                    Heart2.SetActive(true);
                    Heart3.SetActive(true);
                    break;
                case 2:
                    Heart1.SetActive(true);
                    Heart2.SetActive(true);
                    Heart3.SetActive(false);
                    break;
                case 1:
                    Heart1.SetActive(true);
                    Heart2.SetActive(false);
                    Heart3.SetActive(false);
                    break;
                case 0:
                    Heart1.SetActive(false);
                    Heart2.SetActive(false);
                    Heart3.SetActive(false);
                    break;
            }
        }
    }

    public void AddBlock()
    {
        StageBlocksQuantity += 1;
    }

    public void RemoveBlock()
    {
        StageBlocksQuantity -= 1;
        BlockSound.Play();

        if (StageBlocksQuantity == 0)
        {
            NextStage();
        }
    }

    private void NextStage()
    {
        var currentStageIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentStageIndex == FirstStageBuildSettingsIndex)
        {
            SceneManager.LoadScene(SecondStageBuildSettingsIndex);
        }
        else if (currentStageIndex == SecondStageBuildSettingsIndex)
        {
            SceneManager.LoadScene(ThirdStageBuildSettingsIndex);
        }
        else if (currentStageIndex == ThirdStageBuildSettingsIndex)
        {
            SceneManager.LoadScene(EndGameBuildSettingsIndex);
        }
        else
        {
            SceneManager.LoadScene(MenuBuildSettingsIndex);
        }
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("PlayerLives", 3);
        PlayerLives = 3;

        SceneManager.LoadScene(FirstStageBuildSettingsIndex);
    }

    private void RestartGame()
    {
        StartGame();
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene(MenuBuildSettingsIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Leaving game...");
    }

    public void GameOver()
    {
        SceneManager.LoadScene(GameOverBuildSettingsIndex);
    }

    public void RemoveLife()
    {
        if (PlayerLives != 0)
        {
            Debug.Log(PlayerLives);
            PlayerLives -= 1;
            PlayerPrefs.SetInt("PlayerLives", PlayerLives);
        }
        else
        {
            GameOver();
        }
    }
}
