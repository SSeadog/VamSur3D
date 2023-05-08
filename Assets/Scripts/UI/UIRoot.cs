using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    [SerializeField] private List<UIBase> lstUI;

    private ESCMenuUI eSCMenuUI;

    void Start()
    {
        foreach (UIBase uI in lstUI)
        {
            // ���ӿ�����Ʈ �̸��� key�� UIManager�� ���
            GenericSingleton<UIManager>.getInstance().AddUI(uI.gameObject.name, uI);
        }
        eSCMenuUI = GenericSingleton<UIManager>.getInstance().GetUI<ESCMenuUI>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (eSCMenuUI.gameObject.activeSelf == false)
                eSCMenuUI.ShowUI();
            else
                eSCMenuUI.CloseUI();
        }
    }
}
