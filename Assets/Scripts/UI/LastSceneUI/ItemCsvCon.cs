using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class ItemCsvCon : MonoBehaviour
{
    public List<ItemData> lstItemDates = new List<ItemData>();
    void ReadItemData()
    {
        string path = Application.dataPath + "/Resources/Datas/ItemData.csv";//무기정보 받아서 출력값 변경
        if (File.Exists(path))
        {
            string source;
            using (StreamReader sr = new StreamReader(path))
            {
                string[] lines;
                source = sr.ReadToEnd();
                lines = Regex.Split(source, @"\r\n|\n\r|\n|\r");//
                string[] header = Regex.Split(lines[0], ",");//

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = Regex.Split(lines[i], ",");
                    if (values.Length == 0 || string.IsNullOrEmpty(values[0])) continue;

                    ItemData temp = new ItemData();
                    temp.INDEX = int.Parse(values[0]);
                    temp.NAME = (values[1]);
                    temp.LV = int.Parse(values[2]);
                    temp.DMG = int.Parse(values[3]);
                    temp.DPS = float.Parse(values[4]);
                    temp.KILLS = int.Parse(values[5]);
                    lstItemDates.Add(temp);
                    Debug.Log("ReadItemData");
                }
            }
        }
    }
    private void Start()
    {
        ReadItemData();
    }
}
public struct ItemData
{
    public int INDEX;
    public string NAME;
    public int LV;
    public int DMG;
    public float DPS;
    public int KILLS;
}
public enum EItem
{
    none,
    name,
    Lv,
    dmg,
    dps,
    kills,
    max,
}
