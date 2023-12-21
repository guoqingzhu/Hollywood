using System.Collections.Generic;

public class SingleTWData
{
    public string headIconPath;
    public string name;
    public string date;
    public string content;
    public string[] imagesPath;

    public int commentNum;
    public int shareNum;
    public int likeNum;


}


public enum OperationTypes
{
    CHAT = 0,
    CHOOSE = 1,
}

// ѡ������
public class ChooseItemData
{
    public int index;
    public string message;

    public ChooseItemData(int i, string msg)
    {
        index = i;
        message = msg;
    }
}

// ÿ������������
public class OperationInfo
{
    public OperationTypes operationType;
    public string talkMsg;
    public List<ChooseItemData> chooseData;

    public OperationInfo(OperationTypes type, string msg, List<ChooseItemData> data)
    {
        operationType = type;
        talkMsg = msg;
        chooseData = data;
    }

}

// ÿ������������
public class SceneInfo
{
    public string imagePath;
    public List<OperationInfo> operationInfo;

    public SceneInfo(string image, List<OperationInfo> operaions)
    {
        imagePath = image;
        operationInfo = operaions;
    }

}