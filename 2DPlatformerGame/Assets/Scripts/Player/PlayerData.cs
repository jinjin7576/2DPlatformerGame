using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private UIPlayerData uIPlayerData;
    private int coin = 0;
    private int projectile = 0;
    private bool[] stars = new bool[3] { false, false, false };

    public int Coin
    {
        set
        {
            coin = Mathf.Clamp(value, 0, 9999);
            uIPlayerData.SetCoin(coin);
        }
        get => coin;
    }

    public int MaxProjectile { get; } = 10;
    public int CurrentProjectile
    {
        set 
        {
            projectile = Mathf.Clamp(value, 0, MaxProjectile);
            uIPlayerData.setProjectile(projectile, MaxProjectile);
        } 
        get => projectile;
    }
    public bool[] Stars => stars;
    public void GetStar(int index)
    {
        stars[index] = true;
        uIPlayerData.setStar(index);
    }
    private void Awake()
    {
        //Coin = 0;
        CurrentProjectile = 0;
    }
}
