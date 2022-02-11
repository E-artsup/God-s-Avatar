using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private GameObject _mainSection;
    [SerializeField] private GameObject _optionSection;
    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _illus1;
    [SerializeField] private GameObject _illus2;

    private static bool cine = false;

    //private void Awake()
    //{
    //    _animator.SetBool("Starting", true);

    //}


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(cine);


        if (cine)
        {
            _canvas.GetComponent<Animator>().enabled = false;
            _illus1.SetActive(false);
            _illus2.SetActive(false);
        }


        cine = true;


        //_animator.SetTrigger("Start");
        _animator.SetBool("Starting", true);

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
        SceneManager.LoadScene(1, LoadSceneMode.Single);
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
