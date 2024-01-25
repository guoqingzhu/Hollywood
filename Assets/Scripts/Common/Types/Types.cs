using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 一下是开始游戏/进入下一轮游戏的数据类型
/// </summary>
/// 

[Serializable]
public class StartGameReq
{
    public string device_id;
    public string event_id;
}

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
    public Gpt_options gpt_options;
}

[Serializable]
public class ActorData
{
    public string id;
    public string name;
    public string occupation;
    public string identity;
    public string event_v1;
    public string personality;
    public string hobbies;

}

[Serializable]
public class Attributes
{
    public string key;
    public int value;
}

[Serializable]
public class Gpt_options
{
    public string[] dialogue;
    public String monologue;
    public String event_v1;
    public String a;
    public String b;
    public String c;
    public String d;
}

/// <summary>
/// 一下是根据选项获取结果的数据类型
/// </summary>
/// 

[Serializable]
public class GetResultReq
{
    public string device_id;
    public string option_id;
}

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
    public string reaction;
    public string event_progress;
    public string outcome;
    public string headline;
    public string extended_conversation;
}


/// <summary>
/// 以下是根据结果获取新闻评论的数据类型
/// </summary>
/// 

[Serializable]
public class GetcommentsReq
{
    public string device_id;
}


[Serializable]
public class GetCommentType
{
    public string code;
    public string message;
    public GetCommentData data;
}

[Serializable]
public class GetCommentData
{
    public GptNews gpt_news;

}

[Serializable]
public class GptNews
{
    public string post;
    public string[] comments;
}


/// <summary>
/// 获取用户信息的数据类型
/// </summary>
/// 
[Serializable]
public class GetUserInfoType
{
    public string code;
    public string message;
    public GetUserInfoData data;
}

[Serializable]
public class GetUserInfoData
{
    public string id;
    public string device_id;
    public string nickname;
    public string special_npc_name;
    public int age;
    public string gender;
    public string[] personality;
    public string occupation;
    public UserInfoAttribute attribute;
    public RoundInfo current_round;
    public UserFilmInfo film;
}

[Serializable]
public class UserInfoAttribute
{
    public string text;
    public UserValues values;
}


[Serializable]
public class UserValues
{
    public string collaboration;
    public string crime;
    public string facial_expressions;
    public string fame;
    public string favorability;
    public string interest_psychic;
    public string lines_dialogues;
    public string physical_expression;
    public string romance;
    public string science_fiction;
}

[Serializable]
public class RoundInfo
{
    public int number;
    public RoundEvevnt event_v1;
    public ActorData actors;
    public Gpt_options gpt_options;
    public GptOutCome gpt_outcome;
}

[Serializable]
public class RoundEvevnt
{
    public string id;
    public string description;
    public RoundPrompt prompt;
}

[Serializable]
public class RoundPrompt
{
    public string choices_id;
    public string outcome_id;
}

[Serializable]
public class UserFilmInfo
{

}