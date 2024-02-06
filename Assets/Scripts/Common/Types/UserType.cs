using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AddUserReq
{
    public string device_id;
    public string nickname;
    public int age;
    public string gender;
    public string special_npc_name;
}

[Serializable]
public class AddUserType
{
    public int code;
    public string message;
}


[Serializable]
public class PatchUserFilmReq
{
    public string device_id;
    public string key;
    public ActorData[] actors;
}