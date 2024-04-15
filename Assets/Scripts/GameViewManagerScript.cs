using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
using AlphabitAndWords;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameViewManagerScript : MonoBehaviour
{   

    //Один из главных скриптов, отвечает за связь бизнес-логики и отображения

    [SerializeField]
    private GameObject letterList;
    [SerializeField]
    private GameObject letterItemPrefab;
    [SerializeField]
    private GameObject hangman;
    [SerializeField]
    private GameObject keyboard;
    [SerializeField]
    private GameObject keyboardItemPrefab;
    [SerializeField]
    private GameObject gameStateManager;
    [SerializeField]
    private GameObject textManager;

    private List<GameObject> letters = new List<GameObject>();
    private List<GameObject> keyboardItems = new List<GameObject>();
    private GameSession currentSession;
    private HangGame currentGame;

    private void Start()
    {
        gameStateManager.GetComponent<GameStateManagerScript>().activateStart();
        currentSession = new GameSession();
    }

    //Обработчик нажатия кнопки
    public void StartButtonClicked()
    {
        gameStateManager.GetComponent<GameStateManagerScript>().activateMain();
        StartNewGame();
    }

    //Обработчик нажатия кнопки
    public void RestartButtonClicked()
    {
        gameStateManager.GetComponent<GameStateManagerScript>().activateNewGame();
        Clear();
        StartNewGame();
    }

    //Метод подготавливающий поле к новой игре
    void StartNewGame()
    {
        currentGame = currentSession.NewGame();
        hangman.GetComponent<HangmanScript>().Clear();
        foreach(char symbol in AlphabetAndWords.Alphabet)
        {
            GameObject temp = Instantiate(keyboardItemPrefab, keyboard.transform);
            temp.GetComponentInChildren<Text>().text = symbol.ToString();
            keyboardItems.Add(temp);
        }
        foreach(char symbol in currentGame.newWord.GetSymbolList())
        {
            GameObject temp = Instantiate(letterItemPrefab, letterList.transform);
            temp.GetComponentInChildren<Text>().text = "";
            letters.Add(temp);
        }
        AddListenersOnButtons();
    }

    //Метод отчищает поле
    void Clear()
    {
        foreach(GameObject i in letters)
        {
            Destroy(i);
        }
        foreach (GameObject i in keyboardItems)
        {
            Destroy(i);
        }
        letters = new List<GameObject>();
        keyboardItems = new List<GameObject>();
    }

    //Метод срабатывающий при нажатии кнопки клавиатуры
    void Action(char symbol)
    {
        List<int> symbolsList = currentGame.CheckSymbol(symbol); 
        if (currentGame.isGameOver())
        {
            currentSession.UpdateStat();
            TextUpdate();
            gameStateManager.GetComponent<GameStateManagerScript>().activateEndGame();
        }
        if (symbolsList is null)
        {
            hangman.GetComponent<HangmanScript>().Stage();
        }
        else
        {
            foreach (int i in symbolsList)
            {
                letters[i].GetComponentInChildren<Text>().text = symbol.ToString();
            }
        }
    }

    //Метод,подписывающийся на ивенты нажатия кнопок клавиатуры
    void AddListenersOnButtons()
    {
        foreach(GameObject b in keyboardItems)
        {
            b.GetComponent<Button>().onClick.AddListener(delegate { keyboardButtonClicked(b.GetComponentInChildren<Text>().text); });
        }
    }

    //Метод вызываемый после нажатия кнопки
    void keyboardButtonClicked(string message)
    {
        Action(message.ToCharArray()[0]);
    }

    //Обновление отображаемой статистики
    void TextUpdate()
    {
        int[] gameStat = currentSession.GetGameStat();
        textManager.GetComponent<TextMangerScript>().UpdateStat(gameStat[0], gameStat[1]);
        textManager.GetComponent<TextMangerScript>().UpdateGameStatus(currentGame.IsLose());
    }
}
