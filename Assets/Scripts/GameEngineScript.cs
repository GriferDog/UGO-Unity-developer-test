using System.Collections;
using System.Collections.Generic;
using AlphabitAndWords;
using System;
using UnityEngine;
using System.Linq;

namespace GameEngine
{
    //�������� ������-������ ����


    //����� ������ ����� � ������������ ��� ���� ��������
    class Word
    {
        string word;

        public Word(string w)
        {
            word = w;
        }

        public int GetLength()
        {
            return word.Length;
        }

        //����� ������������ ������ �������� ������������ ������� � �����
        //��������, � ����� �������, ����� ������ GetSymbolIndexes('�'), ����� [1,3,6]
        public List<int> GetSymbolIndexes(char symbol)
        {
            List<int> indexes = new List<int>();
            for (int i = 0;i<GetLength(); i++)
            {
                if (word[i] == symbol)
                {
                    indexes.Add(i);
                }
            }
            return indexes;
        }

        //����� ����������� ��� ������������� ������ ����� � ���� ���������
        public List<char> GetSymbolList()
        {
            List<char> symbols = new List<char>();
            foreach(char i in word)
            {
                symbols.Add(i);
            }
            return symbols;
        }
    }

    //����� ������� ����, �������� ���������� �����, ���������� ������ � ���������� �������
    class HangGame
    {
        private int maxMistakes = 6;
        private int mistakes = 0;
        private int rightAnswers = 0;
        public Word newWord;

        public HangGame(string word)
        {
            newWord = new Word(word);
        }

        //����� ���������� � ������ ����������� �����, � ����������� �� ���������� ���������� �������� ������ ��� ���������� �������
        public List<int> CheckSymbol(char symbol)
        {
            int tempRightAnswers = rightAnswers;
            List<int> symbols = newWord.GetSymbolIndexes(symbol);
            foreach (int i in symbols)
            { 
                rightAnswers++;
            }
            if (tempRightAnswers == rightAnswers)
            {
                mistakes++;
                return null;
            }
            else
            {
                return symbols;
            }
        }

        //����� ����������� ��� ����������� ���������
        public bool IsLose()
        {
            if (mistakes > maxMistakes)
            {
                return true;
            }
            else return false;
        }

        //����� ����������� ��� ����������� ��������� ����
        public bool isGameOver()
        {
            if (rightAnswers==newWord.GetLength())
            {
                return true;
            }
            else if (IsLose())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    //����� ������� ������, ������ ��������� ���� ���
    class GameSession
    {
        public int wins = 0;
        public int loses = 0;
        //����� ������� ��������� ���, � �� ����, ����� � ������� ����� ���� �������� ����������(������ � ���������� ������) �� ������ ���������� ����
        List<HangGame> gameList = new List<HangGame>();

        public GameSession()
        {
            newWords();
        }

        //����� ��������� ��������� ������� �� ������ ������
        public HangGame NewGame()
        {   
            int totalGames = wins+loses;
            if (gameList.Count>totalGames)
                return gameList[totalGames];
            else
            {
                newWords();
                return gameList[totalGames];
            }
        }

        //����� ����������� ���������� ����� � ��������� � ������
        public void UpdateStat()
        {
            int totalGames = wins + loses;
            if (gameList[totalGames].isGameOver())
            {
                if (!gameList[totalGames].IsLose()) wins++;
                else loses++;
            }
        }

        //����� ��������� ��������� ���� ����� �������
        void newWords()
        {
            foreach (string word in AlphabetAndWords.GetWords())
            {
                HangGame game = new HangGame(word);
                gameList.Add(game);
            }
        }

        //����� ���������� ������� ����������
        public int[] GetGameStat()
        {
            int[] stat = {wins, loses};
            return stat;
        }

    }
}
