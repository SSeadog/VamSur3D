using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    public class Item // Test
    {
        public int id;
        public string name;
    }

    public class Hero
    {
        public string name;
        public int hp;
        public int moveSpeed;
        public float power;
        public string imageUrl;
    }
    
    public class Weapon
    {
        public int id;
        public int lv;
        public int enhanceLv;
        public float power;
        public int projectileCount;
        public float projectileSpeed;
        public float coolTime;
        public string prefabPath;
        public string imageUrl;
    }

    public enum WeaponType
    {
        Sword = 1,
        Staff,
        Bible,
        FireField,
        Boomerang
    }
}
