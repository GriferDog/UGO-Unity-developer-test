using LanguagesDictionary;
using System.Collections;
using System.Collections.Generic;
using static Unity.VisualScripting.Icons;

namespace LanguagesDictionary
{
    //������� �� ���� ������������ �����
    //������ ������ ��� � ��������� ����� ������� �� �������
    //�������� ����� ��������, �� � ������� ����� � ����� ���������
    //� ������ ������ ����� ���� �� ������ ���������� � �����-������ json

    public enum Languages
    {
        Russian,
        English
    }
    interface ILanguage
    {
        public string mainLabel { get; }
        public string rules {  get; }
        public string newGameButton {  get; }
        public string restartGameButton { get; }
        public string statusWin { get; }
        public string statusLose { get; }
        public string gameStatsWins { get; }
        public string gameStatsLose { get; }
    }

    class Russian: ILanguage
    {
        public string mainLabel { get; } = "���� ��������";
        public string rules { get; } = "����� ������ ����, ��������� �� ����� ����� �� ��������. ���� ���� - ������� �����. � ������ ������������ ������ �� ������ ����� ���������� ������� ��������. ����� �������� �������� ������� �� ������ - �� ���������. ���� �� �������� �����-�� ����� �� �����, �� ��� ����� ����� �������.";
        public string newGameButton { get; } = "������";
        public string restartGameButton { get; } = "������ ��� ���";
        public string statusWin { get; } = "������!!!";
        public string statusLose { get; } = "��� �������� ���������� �����";
        public string gameStatsWins { get; } = "��������: ";
        public string gameStatsLose { get; } = ". ���������: ";
    }

    class English : ILanguage
    {
        public string mainLabel { get; } = "Game HANG";
        public string rules { get; } = "After the game starts, choose one letter from the alphabet. Your goal is to guess the word. With each wrong letter, a gallows element will appear on the screen. When the gallows appears entirely on the screen, you have lost. If you guess a letter from a word, that letter will be revealed.";
        public string newGameButton { get; } = "Play";
        public string restartGameButton { get; } = "Play again";
        public string statusWin { get; } = "You WON!!!";
        public string statusLose { get; } = "They hanged Curly Bobby";
        public string gameStatsWins { get; } = "Won:";
        public string gameStatsLose { get; } = ". Lost: ";
    }

    static class LanguageChooser
    {
        static public ILanguage Choose(Languages lang)
        {
            switch (lang)
            {   
                case Languages.English:
                    return new English();

                default:
                    return new Russian();
            }
        }
    }
}
