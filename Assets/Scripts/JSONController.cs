using UnityEngine;
using System.IO;

public class JSONController : MonoBehaviour
{
    public void SaveMaxScore(StructToRemember structToRemember)
    {
        File.WriteAllText(Application.streamingAssetsPath + "/MaxScore.json", JsonUtility.ToJson(structToRemember));
    }

    public int LoadMaxScore()
    {
        StructToRemember structToRemember = JsonUtility.FromJson<StructToRemember>(File.ReadAllText(Application.streamingAssetsPath + "/MaxScore.json"));
        return structToRemember.MaxScore;
    }
}