using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageOpenGate : MonoBehaviour
{
    Material mat;
    private void Start()
    {
        mat = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (GameManager.Instance.goldKeyCount)
        {
            case 2:
                Destroy(this.gameObject);
                break;
        }
    }
}
