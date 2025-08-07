using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Random = 1 , Coin = 0, Invincibility, HPPotion, Projectile, Star, Count }

public class Constants
{
    //DB의 이름등과 같이 공통으로 사용하는 문자열 정보의 경우 변수를 선언해두고 사용하면 오타 방지 및 수정이 용이
    public static readonly string CurrentLevel = "CURRENT_LEVEL";
}
