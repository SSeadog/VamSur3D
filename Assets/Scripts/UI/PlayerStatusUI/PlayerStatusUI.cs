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
        _playerInfo = GetComponent<PlayerInfo>();
        _itemSlots = GetComponent<ItemSlots>();

        _playerInfo.Init();
        _itemSlots.Init();
    }

    void Update()
    {
        
    }
}
