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

// 选项数据
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

// 每个操作的数据
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

// 每个场景的数据
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