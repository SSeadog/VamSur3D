using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    public class Hero
    {
        public int id;
        public int hp;
        public int moveSpeed;
        public float power;
        public string imageUrl;
        public string prefabPath;
    }
    
    public class Weapon
    {
        public int id;
        public int lv;
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
