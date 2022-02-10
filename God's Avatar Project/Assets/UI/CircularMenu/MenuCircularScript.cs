using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCircularScript : MonoBehaviour
{

    [SerializeField] Vector2 _normalizedMousePosition;
    [SerializeField] float _currentAngle;
    [SerializeField] int _selection;
    private int _previousSelection;

    private HoveringScript _menuItemSc;
    private HoveringScript _previousMenuItemSc;

    [SerializeField] private GameObject[] _MenuItems; 

    // Update is called once per frame
    void Update()
    {
        _normalizedMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        _currentAngle = Mathf.Atan2(_normalizedMousePosition.x, _normalizedMousePosition.y) * Mathf.Rad2Deg;

        _currentAngle = (_currentAngle + 360)%360;
        _selection = (int) _currentAngle / 180;

        if(_selection != _previousSelection)
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
        return _selection;
    }
}
