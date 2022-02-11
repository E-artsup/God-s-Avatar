using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArtefactBoxManager : MonoBehaviour
{
    [SerializeField] private Sprite _rayonSprite;
    [SerializeField] private Sprite _amuletteSprite;
    [SerializeField] private Image _boxImage;
    [SerializeField] private TextMeshProUGUI _boxText;

    public void ChangeEquipedPower(int index)
    {

        switch (index)
        {
            case 0:
                _boxImage.sprite = _rayonSprite;
                _boxText.text = "Rayon";
                break;
            case 1:
                _boxImage.sprite = _amuletteSprite;
                _boxText.text = "Amulette";
                break;
        }

    }
}
