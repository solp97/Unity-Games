using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageOpenGate : MonoBehaviour
{
    Material mat;
    public int needkey;
    private void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.goldKeyCount >= needkey)
        {
            Destroy(this.gameObject);
        }
        
    }
}
