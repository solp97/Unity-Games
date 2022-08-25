using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneStart : MonoBehaviour
{
    public GameObject chaser;
    public AIChaser chaserAI;
    public Animator chaserAnimator;
    public GameObject CutScene2;

    bool cutsceneCheck = false;

    private void Update()
    {
        if(chaserAI.nowStatus == 2 && cutsceneCheck == false)
        {
            CutScene2.SetActive(true);
            cutsceneCheck = true;
        }
    }
    public void AppearChaser()
    {
        chaser.SetActive(true);
    }

    // Start is called before the first frame update
    
}
