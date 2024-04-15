using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlphabitAndWords
{
    //����� �������� ������������ ��� ���������� ������� � ������ ���������� ����
    static class AlphabetAndWords
    {
        public static string Alphabet = "�����Ũ��������������������������";
        private static string[] words = { "������", "�����", "����", "�����", "�������" };

        //����� ������������ � ���������� ������ ����
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