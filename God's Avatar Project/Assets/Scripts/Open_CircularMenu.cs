using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GodAvatar {
    public class Open_CircularMenu : MonoBehaviour
    {

        private Comp_Playerinputs _inputs;
        [SerializeField] private float _holdTimer;
        [SerializeField] private GameObject _CircularMenu;
        [SerializeField] private GameObject _ArtifactBox;
        [SerializeField] private MagicCircle _magicRing;
        public float _timer;
        private bool _menuOpened;

        // Start is called before the first frame update
        void Start()
        {
            _inputs = GetComponent<Comp_Playerinputs>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_inputs.Power.Pressed() && _menuOpened == false)
            {
                _timer++;
            }

            if (_inputs.Power.PressedUp())
            {
                CloseMenu();
                _ArtifactBox.GetComponent<ArtefactBoxManager>().ChangeEquipedPower(_CircularMenu.GetComponent<MenuCircularScript>().GetSelection()); // <-- C'est ici que le changement de pouvoir est fait
                
            }

            if (!(_timer <= _holdTimer) && _menuOpened == false)
            {
                OpenMenu();
            }


        }
        public void OpenMenu()
        {
            _menuOpened = true;
            _CircularMenu.SetActive(true);
            _timer = 0;
        }

        public void CloseMenu()
        {
            _menuOpened = false;
            _CircularMenu.SetActive(false);
            _timer = 0;
        }
    }
}
