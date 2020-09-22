using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagement : MonoBehaviour
{
    public GameObject mainmenu;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool isGameOver()
    {
        return gameOver;
    }

    public void setGameOver()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        mainmenu.SetActive(true);
        gameOver = true;
    }

  
}
