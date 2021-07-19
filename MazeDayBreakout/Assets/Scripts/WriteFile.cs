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

    private void OnGUI()
    {
/*        string temp = "enter here";
        GUILayout.BeginArea(new Rect(0, 0, 1000, 500));
        string dat = GUILayout.TextField(temp, 20);
        GUILayout.EndArea();

        if (!dat.Equals(temp))
            StoreData(dat);*/
    }

}