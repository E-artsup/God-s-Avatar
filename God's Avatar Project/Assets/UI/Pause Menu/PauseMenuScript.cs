using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
=======
>>>>>>> d593fa0281c146abed6b92bbb24447e6d436d2d3

namespace GodAvatar {
    public class PauseMenuScript : MonoBehaviour
    {
        [SerializeField] private GameObject _mainSection;
        [SerializeField] private GameObject _optionSection;
        [SerializeField] private TextMeshProUGUI _titleText;

        public void ShowMainSection()
        {
            _optionSection.SetActive(false);
            _mainSection.SetActive(true);
            _titleText.text = "Pause";
        }

        public void ShowOptionSection()
        {
            _optionSection.SetActive(true);
            _mainSection.SetActive(false);
            _titleText.text = "Option";
        }

<<<<<<< HEAD
        public void MainMenu()
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }


=======
>>>>>>> d593fa0281c146abed6b92bbb24447e6d436d2d3
        public void QuitGame()
        {
            Application.Quit();
        }

    }
}
