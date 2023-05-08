public class PlayerStatusUI : UIBase
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

        SetLv(GenericSingleton<GameManager>.getInstance().HeroLv);
        SetThumbnail("Art/Textures/CharacterThumbnails/Seadog-modified");
    }

    public void AddItem(Define.Weapon weaponData)
    {
        _itemSlots.AddItem(weaponData.imageUrl);
    }

    public void SetLv(int lv)
    {
        _playerInfo.SetLv(GenericSingleton<GameManager>.getInstance().HeroLv);
    }

    public void SetThumbnail(string path)
    {
        _playerInfo.SetThumbnail("Art/Textures/CharacterThumbnails/Seadog-modified");
    }
}
