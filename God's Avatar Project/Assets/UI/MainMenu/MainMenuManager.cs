using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
=======
>>>>>>> d593fa0281c146abed6b92bbb24447e6d436d2d3

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private GameObject _mainSection;
    [SerializeField] private GameObject _optionSection;
<<<<<<< HEAD
    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _illus1;
    [SerializeField] private GameObject _illus2;

    private static bool cine = false;

    //private void Awake()
    //{
    //    _animator.SetBool("Starting", true);

    //}

=======
>>>>>>> d593fa0281c146abed6b92bbb24447e6d436d2d3

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
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

=======
>>>>>>> d593fa0281c146abed6b92bbb24447e6d436d2d3
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
<<<<<<< HEAD
        SceneManager.LoadScene(1, LoadSceneMode.Single);
=======
        
>>>>>>> d593fa0281c146abed6b92bbb24447e6d436d2d3
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
