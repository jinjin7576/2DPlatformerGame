using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

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
        if (isUnlock == true)
        {
            imageFadeScreen.gameObject.SetActive(true);
            StartCoroutine(FadeEffect.Fade(imageFadeScreen, 0, 1, 1 ,AfterFadeEffect));
        }
    }

    private void AfterFadeEffect()
    {
        PlayerPrefs.SetInt(Constants.CurrentLevel, level);
        Utils.LoadScene(SceneName.Game);
    }

    public void SetLevel(int level, bool isUnlock, bool[] stars, Image imageFadeScreen)
    {
        this.level = level;
        this.isUnlock = isUnlock;
        this.imageFadeScreen = imageFadeScreen;

        if (isUnlock == true)
        {
            textLevel.enabled = true;
            textLevel.text = level.ToString();
        }
        else
        {
            imageLevelIcon.sprite = spriteLevelLock;
            textLevel.enabled = false;

            starBackgroundObject.SetActive(false);
        }

        for( int i =0; i < starObjects.Length; ++i)
        {
            starObjects[i].SetActive(stars[i]);
        }
    }

}
