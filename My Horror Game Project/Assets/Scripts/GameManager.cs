using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public GameObject menuUI;
    public int saveDiskCount;
    public int goldKeyCount;
    public CameraRotate camera;

    // Start is called before the first frame update
    void Start()
    {
        saveDiskCount = 0;
        goldKeyCount = 0; ;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            callMenu();
            
        }
    }

    void callMenu()
    {
        menuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        camera.turnSpeed = 0f;
    }
    public void GameContinue()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        camera.turnSpeed = 4f;
    }
    public void GameExit()
    {
        Application.Quit();
    }

   public void GoldKeyCount()
    {
        goldKeyCount++;
    }

    public void SaveDiskCount()
    {
        saveDiskCount++;

    }
}
