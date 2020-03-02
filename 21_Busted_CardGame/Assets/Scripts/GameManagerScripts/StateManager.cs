using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public enum GameState { TitleState, PlayState, PauseState};
    public GameState currentGameState;

    public bool GameStart = false;

    [Header("Game State Stuff")]
    public GameObject Title;
    public GameObject PlayGame;
    public GameObject Pause;
    public GameObject background;

    [Header("Player Name Fields")]
    public InputField p1Name;
    public InputField p2Name;
    public string Player1Name;
    public string Player2Name;
    public Text P1_Name;
    public Text P2_Name;

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameState.TitleState;
        ShowScreen(Title);
        Player1Name = "Player 1";
        Player2Name = "Player 2";
    }

    // Update is called once per frame
    void Update()
    {
        //Updates the player Canvases
        P1_Name.text = Player1Name;
        P2_Name.text = Player2Name;
    }
    //Controller for showing the screens
    private void ShowScreen(GameObject gameObjectToShow)
    {
        Title.SetActive(false);
        PlayGame.SetActive(false);
        Pause.SetActive(false);
        background.SetActive(false);

        gameObjectToShow.SetActive(true);
    }

    //Nameing of Players, Standard names if no input 
    public void SetP1Name()
    {
        Player1Name = p1Name.text;
    }
    public void SetP2Name()
    {
        Player2Name = p2Name.text;
    }
    //When the game is actually played
    public void GamePlay()
    {
        GameStart = true;
        currentGameState = GameState.PlayState;
        ShowScreen(PlayGame);
        background.SetActive(true);
    }
    //when the game is paused
    public void PauseGame()
    {
        currentGameState = GameState.PauseState;
        ShowScreen(Pause);
    }
}
