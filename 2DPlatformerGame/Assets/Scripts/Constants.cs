using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Random = 1 , Coin = 0, Invincibility, HPPotion, Projectile, Star, Count }

public class Constants
{
    public static readonly int MaxLevel = 10;
    public static readonly int StarCount = 3;

    //DB�� �̸���� ���� �������� ����ϴ� ���ڿ� ������ ��� ������ �����صΰ� ����ϸ� ��Ÿ ���� �� ������ ����
    public static readonly string CurrentLevel = "CURRENT_LEVEL";
    public static readonly string LevelUnlock = "LEVEL_UNLOCK_";
    public static readonly string LevelStar = "LEVEL_STAR_";

    public static (bool, bool[]) LoadLevelData(int level)
    {
        bool isUnlock = PlayerPrefs.GetInt($"{LevelUnlock}{level}", 0) == 1 ? true : false;
        bool[] stars = new bool[StarCount];

        for (int index = 0; index < StarCount; ++index)
        {
            stars[index] = PlayerPrefs.GetInt($"{LevelStar}{level}{index}", 0) == 1 ? true : false;
        }
        return (isUnlock, stars);
    }
}
