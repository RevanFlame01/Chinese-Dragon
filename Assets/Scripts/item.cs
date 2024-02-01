using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public static int itemStatus = 0;

    [SerializeField] private GameObject itemButton;
    private void Start()
    {
        itemStatus = PlayerPrefs.GetInt("itemStatus");
    }

    private void Update()
    {
        PlayerPrefs.SetInt("itemStatus", itemStatus);
        if (itemStatus == 1)
        {
            itemButton.SetActive(true);
        }
        if(itemStatus ==0)
        {
            itemButton.SetActive(false);
        }
    }


    public void OnButtonClik()
    {
        itemStatus = 0;
        PlayerController.hp++;
    }
}
