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
    
}
