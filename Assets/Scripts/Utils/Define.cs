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
    public class Monster
    {
        public int id;
        public int hp;
        public int exp;
        public int projectileCount;
        public float power;
        public int exp;
        public string prefabPath;
        public string imageUrl;
    }

    public enum HeroType
    {
        SwordHero = 1,
        Wizard
    }

    public enum WeaponType
    {
        Sword = 1,
        Staff,
        Bible,
        FireField,
        Boomerang
    }
    public enum MonsterType
    {
        NormalMob = 1,
        ProjectileMob,
        EliteMob,
        Max
    }
}
