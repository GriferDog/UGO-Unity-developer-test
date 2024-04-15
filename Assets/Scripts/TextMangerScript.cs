using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LanguagesDictionary;
using UnityEngine.UI;


public class TextMangerScript : MonoBehaviour
{
    //Скрипт, позволяющий переключать язык прямо во время игры
    //Так же он используется для обновления результата и статистики игры

    [SerializeField]
    private Languages language;
    [SerializeField]
    private GameObject labelTextBox;
    [SerializeField]
    private GameObject rulesTextBox;
    [SerializeField]
    private GameObject newGameButtonTextBox;
    [SerializeField]
    private GameObject restartGameButtonTextBox;
    [SerializeField]
    private GameObject statusTextBox;
    [SerializeField]
    private GameObject gameStatTextBox;

    void Start()
    {
        textSwitcher();
    }

    private void textSwitcher()
    {
        ILanguage langModel = LanguageChooser.Choose(language);
        labelTextBox.GetComponent<Text>().text = langModel.mainLabel;
        rulesTextBox.GetComponent<Text>().text = langModel.rules;
        newGameButtonTextBox.GetComponent<Text>().text = langModel.newGameButton;
        restartGameButtonTextBox.GetComponent<Text>().text = langModel.restartGameButton;
        UpdateGameStatus(true);
        UpdateStat(0, 0);
    }

    //Метод выбирает надпись в зависимости от исхода игры
    public void UpdateGameStatus(bool isLose)
    {
        ILanguage langModel = LanguageChooser.Choose(language);
        if (!isLose)
        {
            statusTextBox.GetComponent<Text>().text = langModel.statusWin;
        }
        else
        {
            statusTextBox.GetComponent<Text>().text = langModel.statusLose;
        }

    }

    //Метод формирует строку статистики
    public void UpdateStat(int win, int lose)
    {
        ILanguage langModel = LanguageChooser.Choose(language);
        gameStatTextBox.GetComponent<Text>().text = langModel.gameStatsWins + win.ToString() + langModel.gameStatsLose + lose.ToString();
    }
}
