using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusUI : MonoBehaviour
{
    // Todo
    // CharacterInfo UI�� ĳ���� ����� �ε�
    // CharacterInfo UI�� ���� �ݿ��Ͽ� �����ֵ���
    // ItemSlots UI�� ȹ���� ������ �����ֵ���
    // �� ������ ���� �����Ϳ� �����ǵ��� ����Ͽ� ��� ����

    PlayerInfo _playerInfo;
    ItemSlots _itemSlots;

    void Start()
    {
        _playerInfo = GetComponentInChildren<PlayerInfo>();
        _itemSlots = GetComponentInChildren<ItemSlots>();

        SetLv(Managers.Game.heroLv);
        SetThumbnail("Art/Textures/CharacterThumbnails/Seadog-modified");
    }

    public void AddItem(Define.Weapon weaponData)
    {
        _itemSlots.AddItem(weaponData.imageUrl);
    }

    public void SetLv(int lv)
    {
        _playerInfo.SetLv(Managers.Game.heroLv);
    }

    public void SetThumbnail(string path)
    {
        _playerInfo.SetThumbnail("Art/Textures/CharacterThumbnails/Seadog-modified");
    }
}
