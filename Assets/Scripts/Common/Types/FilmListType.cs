using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 获取电影列表的请求数据
/// 目前只有演员数量 actor_num是必要的
/// </summary>
[Serializable]
public class GetFilmListReq
{
    public string name;
    public int actor_num;
    public int pageSize;
    public int pageNum;
    public int sort;
}

[Serializable]
public class FilmListType
{
    public string code;
    public string message;
    public FilmListData data;
}

[Serializable]
public class FilmListData
{
    public int total;
    public FilmData[] list;
    public int pageSize;
    public int pageNum;
    public int size;
    public int startRow;
    public int endRow;
    public int pages;
    public int prePage;
    public int nextPage;
    public bool isFirstPage;
    public bool isLastPage;
    public bool hasPreviousPage;
    public bool hasNextPage;
    public int navigatePages;
    public int[] navigatePageNums;
    public int navigateFirstPage;
    public int navigateLastPage;

}


[Serializable]
public class FilmData
{
    public string key;
    public string name;
    public ActorData[] actors;
    public string[] labels;
    public string synopsis;

}
