using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class Item: MonoBehaviour
{
    public List<ItemDate> lstItemDate = new List<ItemDate>();
    public void itemdate()
    {
        string itmepath = Application.dataPath + "/Resources/Datas/ItemDate.csv";
             if (File.Exists(itmepath))
        {
            string source;
            using (StreamReader sr = new StreamReader(itmepath))
            {
                string[] lines;
                source = sr.ReadToEnd();
                lines = Regex.Split(source, @"\r\n|\n\r|\n|\r");//
                string[] header = Regex.Split(lines[0], ",");//

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = Regex.Split(lines[i], ",");
                    if (values.Length == 0 || string.IsNullOrEmpty(values[0])) continue;

                    ItemDate temp = new ItemDate();
                    temp.INDEX = int.Parse(values[0]);
                    temp.NAME = (values[1]);
                    temp.LV = int.Parse(values[2]);
                    temp.DMG = int.Parse(values[3]);
                    temp.DPS = float.Parse(values[4]);
                    temp.KILLS = int.Parse(values[5]);
                    lstItemDate.Add(temp);
                }
            }
        }
    }  
    void Update()
    {
        
    }
}
public struct ItemDate
{
    public int INDEX;
    public string NAME;
    public int LV;
    public int DMG;
    public float DPS;
    public int KILLS;
}
