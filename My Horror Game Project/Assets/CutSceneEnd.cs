using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnd : MonoBehaviour
{
    public GameObject mycams;
    // Start is called before the first frame update
    public void CutSceneIsEnd()
    {
        mycams.SetActive(true);
    }
}
