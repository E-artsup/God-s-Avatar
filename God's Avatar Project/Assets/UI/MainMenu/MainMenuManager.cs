using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private GameObject _mainSection;
    [SerializeField] private GameObject _optionSection;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopCutscene()
    {
        
    }

    public void StartGame()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowMainSection()
    {
        _mainSection.SetActive(true);
        _optionSection.SetActive(false);
    }

    public void ShowOptionSection()
    {
        _mainSection.SetActive(false);
        _optionSection.SetActive(true);
    }

}
