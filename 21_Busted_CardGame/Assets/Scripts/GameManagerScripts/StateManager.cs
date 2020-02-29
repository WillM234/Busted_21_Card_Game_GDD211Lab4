using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public enum GameState { TitleState, PlayState, PauseState, EndGameState };
    public GameState currentGameState;

    public bool GameStart = false;

    [Header("Game State Stuff")]
    public GameObject Title;
    public GameObject PlayGame;
    public GameObject Pause;
    public GameObject End;
    public GameObject background;

    [Header("Player Name Fields")]
    public InputField p1Name;
    public InputField p2Name;
    public string Player1Name;
    public string Player2Name;

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameState.TitleState;
        ShowScreen(Title);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ShowScreen(GameObject gameObjectToShow)
    {
        Title.SetActive(false);
        PlayGame.SetActive(false);
        Pause.SetActive(false);
        End.SetActive(false);
        background.SetActive(false);

        gameObjectToShow.SetActive(true);
    }
    public void SetP1Name()
    {
        Player1Name = p1Name.text;
    }
    public void SetP2Name()
    {
        Player2Name = p2Name.text;
    }
    public void GamePlay()
    {
        GameStart = true;
        currentGameState = GameState.PlayState;
        ShowScreen(PlayGame);
        background.SetActive(true);
    }
    public void PauseGame()
    {
        currentGameState = GameState.PauseState;
        ShowScreen(Pause);
    }
    public void EndGame()
    {
        currentGameState = GameState.EndGameState;
        ShowScreen(End);
    }

}
