using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelController : MonoBehaviour
{
    [Header("Fade Effect")]
    [SerializeField]
    private Image imageFadeScreen;

    [Header("Level UI")]
    [SerializeField]
    private UILevel LevelPrefab;
    [SerializeField]
    private Transform levelParent;

    private void Awake()
    {
        StartCoroutine(FadeEffect.Fade(imageFadeScreen, 1, 0, 1, AfterFadeEffect));
        LoadLevelData();
    }

    private void LoadLevelData()
    {
        PlayerPrefs.SetInt($"{Constants.LevelUnlock}1", 1);
        
        for (int i = 0; i<= Constants.MaxLevel; ++i)
        {
            UILevel level = Instantiate(LevelPrefab, levelParent);
            (bool, bool[]) levelData = Constants.LoadLevelData(i);

            level.SetLevel(i, levelData.Item1, levelData.Item2, imageFadeScreen);
        }
    }

    private void AfterFadeEffect()
    {
        imageFadeScreen.gameObject.SetActive(false);
    }

    [ContextMenu("ResetData")]
    private void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
