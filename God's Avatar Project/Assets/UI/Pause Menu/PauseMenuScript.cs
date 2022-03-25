using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public void MainMenu()
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }


        public void QuitGame()
        {
            Application.Quit();
        }

    }
}
