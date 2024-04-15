using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManagerScript : MonoBehaviour
{
    //Скрипт необходимый для переключения между разными состояниями сцены

    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject startGame;
    [SerializeField]
    private GameObject mainGameMenu;
    [SerializeField]
    private GameObject restartGameMenu;

    void Start()
    {
        activateStart();
    }

    public void activateStart()
    {
        startGame.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void activateMain()
    {
        mainMenu.SetActive(false);
        startGame.SetActive(true);
    }

    public void activateEndGame()
    {
        mainGameMenu.SetActive(false);
        restartGameMenu.SetActive(true);
    }

    public void activateNewGame()
    {
        restartGameMenu.SetActive(false);
        mainGameMenu.SetActive(true);
    }
}
