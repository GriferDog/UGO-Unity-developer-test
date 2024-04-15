using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangmanScript : MonoBehaviour
{   
    //Скрипт необходим для переключения состояния висельника
    private int stage;
    private List<GameObject> imageList = new List<GameObject>();

    //В самом начале собираются все приложенные картинки
    void Start()
    {
        int temp = gameObject.transform.childCount;
        for (int i = 0;i<temp;i++)
        {
            imageList.Add(gameObject.transform.GetChild(i).gameObject);
        }
        Clear();
    }

    //Метод отчищает картинку для новой игры
    public void Clear()
    {
        stage = 0;
        foreach (GameObject image in imageList)
        {
            image.SetActive(false);
        }
    }

    //Увеличение картинки в случае ошибки
    public void Stage()
    {
        imageList[stage].SetActive(true);
        stage++;
    }
}
