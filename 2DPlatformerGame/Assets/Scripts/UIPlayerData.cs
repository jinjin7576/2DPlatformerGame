using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayerData : MonoBehaviour
{
    [Header("HP")]
    [SerializeField]
    private Image[] hpImgae;

    [Header("COIN")]
    [SerializeField]
    private TextMeshProUGUI textCoin;

    [Header("Projectile")]
    [SerializeField]
    private TextMeshProUGUI textProjectile;

    [Header("Star")]
    [SerializeField]
    private Image[] starImage;
    public void SetHp(int index, bool isActive)
    {
        hpImgae[index].color = isActive == true ? Color.white : Color.black;
    }

    public void SetCoin(int coinCount)
    {
        textCoin.text = $"x {coinCount}";
    }
    public void setProjectile(int current , int max)
    {
        textProjectile.text = $"{current} / {max}";

        if (((float)current / max) <= 0.3f) textProjectile.color = Color.red;
        else textProjectile.color = Color.white;
    }
    public void setStar(int index)
    {
        starImage[index].gameObject.SetActive(true);
    }
}
