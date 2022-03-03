using GodAvatar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    private bool _pause;
    [SerializeField] private GameObject _pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (_pause == false)
        {
            Time.timeScale = 1f;
            _pauseMenu.SetActive(true);
            _pause = true;
            return;
        }

        Time.timeScale = 0f;
        _pauseMenu.GetComponent<PauseMenuScript>().ShowMainSection();
        _pauseMenu.SetActive(false);
        _pause = false;
    }
}
