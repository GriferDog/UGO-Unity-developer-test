using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButton : MonoBehaviour
{
    //Изменение вида использованной кнопки
    public void OnClickDisable()
    {
        gameObject.GetComponent<Button>().enabled = false;
        gameObject.GetComponent<Image>().color = Color.gray;
    }
}
