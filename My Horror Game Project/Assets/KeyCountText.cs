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
    private void OnEnable()
    {
        mytext.text = "Ȳ�� ����: " + GameManager.Instance.goldKeyCount + "\n Ȳ�� ��ũ:" + GameManager.Instance.saveDiskCount;
    }
}
