using System.Collections.Generic;


/// <summary>
/// ÿһ�����ĵ���Ϣ
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
/// ֪ͨ���� ����֪ͨ����Ϣ
/// </summary>
public class SingleNotification
{
    public string headIconPath;
    public string name;
    public string date;
    public string content;
}

/// <summary>
/// ��Ϣ���� ������Ϣ�����ݽṹ
/// </summary>
public class SingleMessageTip
{
    public string headIconPath;
    public string name;
    public string date;
    public string content;
}

/// <summary>
/// ������������ʼ���õ�����
/// </summary>
public class ChatInitData
{
    public string name; // �����������
    public string headIconPath; // �������ͷ��
    public SingleChatContent[] contents; // ��������������
}

/// <summary>
/// ��������ڵĵ�����������
/// </summary>
public class SingleChatContent
{
    public string name;//������Ϣ����
    public string content;//����
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