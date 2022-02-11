using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GodAvatar
{
    public class MenuCircularScript : MonoBehaviour
    {

        [SerializeField] Vector2 _normalizedMousePosition;
        [SerializeField] float _currentAngle;
        [SerializeField] int _selection;
        [SerializeField] private UseRayon _beamScript;

        private int _previousSelection;

        private HoveringScript _menuItemSc;
        private HoveringScript _previousMenuItemSc;

        [SerializeField] private GameObject[] _MenuItems;

        // Update is called once per frame
        void Update()
        {
            _normalizedMousePosition = new Vector2(UnityEngine.Input.mousePosition.x - Screen.width / 2, UnityEngine.Input.mousePosition.y - Screen.height / 2);
            _currentAngle = Mathf.Atan2(_normalizedMousePosition.x, _normalizedMousePosition.y) * Mathf.Rad2Deg;

            _currentAngle = (_currentAngle + 360) % 360;
            _selection = (int)_currentAngle / 180;

            if (_selection != _previousSelection)
            {
                _previousMenuItemSc = _MenuItems[_previousSelection].GetComponent<HoveringScript>();
                _previousMenuItemSc.Deselect();
                _previousSelection = _selection;

                _menuItemSc = _MenuItems[_selection].GetComponent<HoveringScript>();
                _menuItemSc.Select();
            }

        }

        public int GetSelection()
        {
            if (_selection == 1)
            {
                _beamScript._beamSelected = false;
            }
            else
            {
                _beamScript._beamSelected = true ;

            }
            return _selection;
        }
    }
}

