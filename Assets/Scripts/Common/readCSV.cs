using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class readCSV : MonoBehaviour
{

    public static List<string> readFile(string path)
    {
        // ����CSV�ļ�·��
        string filePath = path;

        // ʹ��Resources.Load����CSV�ļ�ΪTextAsset����
        TextAsset csvFile = Resources.Load<TextAsset>(filePath);

        // ����һ��List���洢CSV�ļ�����
        List<string> csvData = new List<string>();

        // ʹ��StringReader��ȡCSV�ļ�����
        using (StringReader reader = new StringReader(csvFile.text))
        {
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                csvData.Add(line);
            }
        }

        return csvData;
    }
}
