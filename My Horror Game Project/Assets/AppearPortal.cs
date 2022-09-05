using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearPortal : MonoBehaviour
{
    public int needKey;
    public GameObject clearText;
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.goldKeyCount <= needKey)
        {
            this.gameObject.SetActive(true);
        }
        else this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        clearText.SetActive(true);
    }
}
