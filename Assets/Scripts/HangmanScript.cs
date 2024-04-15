using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangmanScript : MonoBehaviour
{   
    //������ ��������� ��� ������������ ��������� ����������
    private int stage;
    private List<GameObject> imageList = new List<GameObject>();

    //� ����� ������ ���������� ��� ����������� ��������
    void Start()
    {
        int temp = gameObject.transform.childCount;
        for (int i = 0;i<temp;i++)
        {
            imageList.Add(gameObject.transform.GetChild(i).gameObject);
        }
        Clear();
    }

    //����� �������� �������� ��� ����� ����
    public void Clear()
    {
        stage = 0;
        foreach (GameObject image in imageList)
        {
            image.SetActive(false);
        }
    }

    //���������� �������� � ������ ������
    public void Stage()
    {
        imageList[stage].SetActive(true);
        stage++;
    }
}
