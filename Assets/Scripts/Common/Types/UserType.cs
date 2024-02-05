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
}

[Serializable]
public class AddUserType
{
    public int code;
    public string message;
}