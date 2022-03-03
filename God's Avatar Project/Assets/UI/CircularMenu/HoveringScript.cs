using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoveringScript : MonoBehaviour
{

    public Color _hoverColor;
    public Color _baseColor;
    public Image _background;
    public GameObject _name;

    // Start is called before the first frame update
    void Start()
    {
        _background.color = _baseColor;
    }

    // Update is called once per frame
    public void Select()
    {
        _background.color = _hoverColor;
        _name.SetActive(true);
    }

    public void Deselect()
    {
        _background.color = _baseColor;
        _name.SetActive(false);
    }
}
