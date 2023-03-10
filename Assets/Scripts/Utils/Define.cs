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
        public float power;
        public int enforce;
        public string imageUrl;
    }

    enum WeaponType
    {
        Sword,
        Staff,
        Bible,
        FireField,
        Boomerang
    }


}
