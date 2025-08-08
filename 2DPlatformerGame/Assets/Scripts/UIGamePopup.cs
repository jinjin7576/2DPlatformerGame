using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePopup : MonoBehaviour
{
    [Header("���� : ���� ���")]
    [SerializeField]
    private GameObject overlayBackground;

    [Header("�Ͻ� ����")]
    [SerializeField]
    private GameObject popupPause;

    [Header("���� ����")]
    [SerializeField]
    private GameObject popupLevelFailed;

    [Header("���� ����")]
    [SerializeField]
    private GameObject popupLevelComplete;
    [SerializeField]
    private GameObject[] starObjects;



    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
    public void Pause()
    {
        SetTimeScale(0);
        overlayBackground.SetActive(true);
        popupPause.SetActive(true);
    }

    public void LevelFailed()
    {
        SetTimeScale(0);
        overlayBackground.SetActive(true);
        popupLevelFailed.SetActive(true);
    }

    public void LevelComplete(bool[] stars)
    {
        SetTimeScale(0);
        overlayBackground.SetActive(true);
        popupLevelComplete.SetActive(true);

        for(int i = 0; i < starObjects.Length; ++i)
        {
            starObjects[i].SetActive(stars[i]);
        }
    }

    public void Resume()
    {
        SetTimeScale(1);
        overlayBackground.SetActive(false);
        popupPause.SetActive(false);
    }
    public void SelectLevel()
    {
        SetTimeScale(1);
        Utils.LoadScene(SceneName.SelectLevel);
    }
    public void Restart()
    {
        SetTimeScale(1);
        Utils.LoadScene();
    }

    public void NextLevel()
    {
        SetTimeScale(1);
        int currentLevel = PlayerPrefs.GetInt(Constants.CurrentLevel);
        if (currentLevel >= Constants.MaxLevel)
        {
            SelectLevel();
        }
        else
        {
            PlayerPrefs.SetInt(Constants.CurrentLevel, currentLevel + 1);
            Utils.LoadScene();
        }
    }
}
