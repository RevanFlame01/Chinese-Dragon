using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class superButton : MonoBehaviour
{
    [SerializeField] private Image button;
    public static float fillAmount =0;

    private void Start()
    {
        button = GetComponent<Image>();
        
    }

    private void Update()
    {
        button.fillAmount = fillAmount;
    }
}
