using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlphabitAndWords
{
    //«десь хранитс€ используемый дл€ клавиатуры алфавит и список загаданных слов
    static class AlphabetAndWords
    {
        public static string Alphabet = "јЅ¬√ƒ≈®∆«»… ЋћЌќѕ–—“”‘’÷„ЎўЏџ№Ёёя";
        private static string[] words = { "—”Ќƒ” ", "ѕќ ≈–", "¬»Ћџ", "–”ћЅј", " ј–јћЅј" };

        //метод перемешивает и возвращает список слов
        public static string[] GetWords()
        {
            List<string> shuffeledWords = new List<string>();
            for (int i = 0;i<words.Count(); i++)
            {
                int randIndex = new Random().Next(i,words.Count());
                string temp = words[i];
                words[i] = words[randIndex];
                words[randIndex] = temp;
            }
            return words;
        }
        
    }
}