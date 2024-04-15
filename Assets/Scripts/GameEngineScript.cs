using System.Collections;
using System.Collections.Generic;
using AlphabitAndWords;
using System;
using UnityEngine;
using System.Linq;

namespace GameEngine
{
    //Основная бизнес-логика игры


    //Класс нового слова с необходимыми для игры методами
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

        //Метод возвращающий список индексов запрошенного символа в слове
        //Например, в слове КАРАМБА, вызов метода GetSymbolIndexes('А'), вернёт [1,3,6]
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

        //Метод необходимый для посимвольного вывода слова в виде коллекции
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

    //Класс текущей игры, содержит загаданное слово, количество ошибок и правильных ответов
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

        //Метод обращается к методу загаданного слова, в зависимости от результата увеличивет колиство ошибок или правильных ответов
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

        //Метод необходимый для определения поражения
        public bool IsLose()
        {
            if (mistakes > maxMistakes)
            {
                return true;
            }
            else return false;
        }

        //Метод необходимый для определения окончания игры
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


    //Класс игровой сессии, хранит коллекцию всех игр
    class GameSession
    {
        public int wins = 0;
        public int loses = 0;
        //Решил создать коллекцию игр, а не слов, чтобы в будущем можно было выводить статистику(ошибки и правильные ответы) по каждой конкретной игре
        List<HangGame> gameList = new List<HangGame>();

        public GameSession()
        {
            newWords();
        }

        //Метод запускает следующий уровень из своего списка
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

        //Метод обновляющий количество побед и поражений в сессии
        public void UpdateStat()
        {
            int totalGames = wins + loses;
            if (gameList[totalGames].isGameOver())
            {
                if (!gameList[totalGames].IsLose()) wins++;
                else loses++;
            }
        }

        //Метод дополняет коллекцию слов новым списком
        void newWords()
        {
            foreach (string word in AlphabetAndWords.GetWords())
            {
                HangGame game = new HangGame(word);
                gameList.Add(game);
            }
        }

        //Метод возвращает игровую статистику
        public int[] GetGameStat()
        {
            int[] stat = {wins, loses};
            return stat;
        }

    }
}
