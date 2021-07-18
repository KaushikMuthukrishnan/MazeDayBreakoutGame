using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WriteFile : MonoBehaviour
{
    private string filePath = Application.streamingAssetsPath + "/InputData/data.json";
    private void Awake()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/InputData/");
    }
    public void WriteData(Dictionary<string, string[]> dict)
    {
        dict.
        File.AppendAllText(filePath);
    }
    
}
