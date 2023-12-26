using System.Collections.Generic;


/// <summary>
/// 每一条推文的信息
/// </summary>
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

/// <summary>
/// 通知界面 单条通知的信息
/// </summary>
public class SingleNotification
{
    public string headIconPath;
    public string name;
    public string date;
    public string content;
}

/// <summary>
/// 消息界面 单条消息的数据结构
/// </summary>
public class SingleMessageTip
{
    public string headIconPath;
    public string name;
    public string date;
    public string content;
}

/// <summary>
/// 进入聊天界面初始化用的数据
/// </summary>
public class ChatInitData
{
    public string name; // 聊天对象名字
    public string headIconPath; // 聊天对象头像
    public SingleChatContent[] contents; // 以往的聊天内容
}

/// <summary>
/// 聊天界面内的单条聊天内容
/// </summary>
public class SingleChatContent
{
    public string name;//发送消息的人
    public string content;//内容
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