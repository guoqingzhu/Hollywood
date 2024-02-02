using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class readCSV : MonoBehaviour
{

    public static List<string> readFile(string path)
    {
        // 定义CSV文件路径
        string filePath = path;

        // 使用Resources.Load加载CSV文件为TextAsset对象
        TextAsset csvFile = Resources.Load<TextAsset>(filePath);

        // 创建一个List来存储CSV文件内容
        List<string> csvData = new List<string>();

        // 使用StringReader读取CSV文件内容
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
