using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetManger : MonoBehaviour
{
    private static NetManger _instance;


    public static NetManger GetInstance()
    {
        return _instance ?? (_instance = new NetManger());
    }

    // 发送GET请求
    public void SendGetRequest(string url, System.Action<string> onSuccess, System.Action<string> onFailure)
    {
        StartCoroutine(GetRequest(url, onSuccess, onFailure));
    }

    // 发送POST请求
    public void SendPostRequest(string url, string postData, System.Action<string> onSuccess, System.Action<string> onFailure)
    {
        StartCoroutine(PostRequest(url, postData, onSuccess, onFailure));
    }

    IEnumerator GetRequest(string uri, System.Action<string> onSuccess, System.Action<string> onFailure)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                onFailure?.Invoke(webRequest.error);
            }
            else
            {
                onSuccess?.Invoke(webRequest.downloadHandler.text);
            }
        }
    }

    IEnumerator PostRequest(string uri, string postData, System.Action<string> onSuccess, System.Action<string> onFailure)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection(postData));

        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, formData))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                onFailure?.Invoke(webRequest.error);
            }
            else
            {
                onSuccess?.Invoke(webRequest.downloadHandler.text);
            }
        }
    }
}

