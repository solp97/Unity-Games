using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCountText : MonoBehaviour
{
    private Text mytext;
    private void Start()
    {
        mytext = GetComponent<Text>();
    }
    private void Update()
    {
        mytext.text = "황금 열쇠: " + GameManager.Instance.goldKeyCount + "\n황금 디스크:" + GameManager.Instance.saveDiskCount;
    }

}
