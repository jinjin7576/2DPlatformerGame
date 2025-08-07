using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UILevel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    Sprite spriteLevelLock;
    [SerializeField]
    Image imageLevelIcon;
    [SerializeField]
    private TextMeshProUGUI textLevel;
    [SerializeField]
    GameObject starBackgroundObject;
    [SerializeField]
    GameObject[] starObjects;

    int level;
    bool isUnlock;
    Image imageFadeScreen;

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
