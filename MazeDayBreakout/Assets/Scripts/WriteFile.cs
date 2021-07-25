using System.IO;
using UnityEngine;

public class WriteFile : MonoBehaviour
{
    private string filePath = Application.streamingAssetsPath + "/InputData/data.txt";
    private void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/InputData/");
    }
    public void StoreData(string text)
    {
        File.AppendAllText(filePath, text + "\n");
    }

}