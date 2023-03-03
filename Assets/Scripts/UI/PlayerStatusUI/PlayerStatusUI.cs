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

    void Awake()
    {
        _playerInfo = GetComponentInChildren<PlayerInfo>();
        _playerInfo.Init();
        _itemSlots = GetComponentInChildren<ItemSlots>();
        _itemSlots.Init();

        _playerInfo.SetLv(99);
        _playerInfo.SetThumbnail("Art/Textures/CharacterThumbnails/Seadog-modified");
    }

    public void AddItem(Define.Weapon weaponData)
    {
        _itemSlots.AddItem(weaponData.imageUrl);
    }
}
