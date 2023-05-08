using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SelectedInfoBox : MonoBehaviour
{
    CharacterBoxController cb;
    WeaponBoxController wb;
    Transform hoveringCharacterBox;
    Transform selectedBackground;

    public Transform SelectBackground { get { return selectedBackground; } }

    Vector3 Maxv3 = new Vector3(1.05f, 1.05f, 1.05f);
    Vector3 Minv3 = Vector3.one;

    
    public void OnClickedCharacterBox()
    { 
        hoveringCharacterBox = gameObject.transform;
        selectedBackground = hoveringCharacterBox.Find("SelectedImageBackground");
        cb.isBeforeBoxInfo(this);
        cb.getMenuUIControllerData();
        selectedBackground.gameObject.SetActive(true);
        
        StartCoroutine(ClickCharacterBoxEvent());
    }

    public void OnClickedWeaponBox()
    {

        hoveringCharacterBox = gameObject.transform;
        selectedBackground = hoveringCharacterBox.Find("SelectedImageBackground");
        wb.isBeforeBoxInfo(this);
        wb.getMenuUIControllerData();
        selectedBackground.gameObject.SetActive(true);

        StartCoroutine(ClickCharacterBoxEvent());
    }

    public void Init(CharacterBoxController cbc)
    {
        cb = cbc;
    }

    public void Init(WeaponBoxController wbc)
    {
        wb = wbc;
    }

    IEnumerator ClickCharacterBoxEvent()
    {
        while (true)
        {
            selectedBackground.DOScale(Maxv3, 1f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(1);
            selectedBackground.DOScale(Minv3, 1f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(0.5f);
        }
    }

}

