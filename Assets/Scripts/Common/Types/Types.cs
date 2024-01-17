using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 一下是开始游戏/进入下一轮游戏的数据类型
/// </summary>
/// 

[Serializable]
public class StartGameType
{
    public string code;
    public string message;
    public StartGameData data;
}

[Serializable]
public class StartGameData
{
    public string event_theme;
    public ActorData[] actors;
    public int difficulty_value;
    public int round_number;
    public string welcome_message;
    public string location;
    public string weather;
    public Attributes[] attribute_values;
    public Gpt_options[] gpt_options;
}

[Serializable]
public class ActorData
{
    public string id;
    public string name;
    public string occupation;
    public string identity;
    public string event_name;
    public string personality;
    public string hobbies;

}

[Serializable]
public class Attributes
{
    public string Key;
    public int Value;
}

[Serializable]
public class Gpt_options
{
    public string[] Dialogue;
    public String Monologue;
    public String Event;
    public String A;
    public String B;
    public String C;
    public String D;
}

/// <summary>
/// 一下是根据选项获取结果的数据类型
/// </summary>
[Serializable]
public class GetResultType
{
    public string code;
    public string message;
    public ResultTypeData data;
}

[Serializable]
public class ResultTypeData
{
    public OptionOutCome option_outcome;
    public GptOutCome gpt_outcome;
}

[Serializable]
public class OptionOutCome
{
    public string text;
    public string short_text;
}

[Serializable]
public class GptOutCome
{
    public string Rection;
    public string Event_Progress;
    public string Outcome;
    public string Headline;
    public string Exended_Conversation;
}


/// <summary>
/// 以下是根据结果获取新闻评论的数据类型
/// </summary>
[Serializable]
class GetCommentType
{
    public string code;
    public string message;
    public GetCommentData data;
}

[Serializable]
class GetCommentData
{
    public GptNews[] gpt_news;

}

[Serializable]
class GptNews
{
    public string Post;
    public string[] Comments;
}