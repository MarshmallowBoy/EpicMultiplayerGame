using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public TextMeshProUGUI text;
    public RectTransform backgroundImage;
    void Update()
    {
        backgroundImage.sizeDelta = text.rectTransform.sizeDelta;
    }
}
