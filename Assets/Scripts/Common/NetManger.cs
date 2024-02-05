using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetManger : MonoBehaviour
{
    public static string devpath = "http://121.40.64.87:8091/";
    //public static string devpath = "http://172.40.2.4:8091/";

    public static string getUserInfo = "hollywood/members";

    public static string startGame = "hollywood/members/start-or-nextround";
    public static string getResult = "hollywood/members/outcome";
    public static string getComment = "hollywood/members/outcome-news";
    public static string getFilmList = "hollywood/screenplays";
    public static string addUser = "hollywood/members/enter";
    public static string patchFilm = "hollywood/members/screenplay";

    private static NetManger _instance;


    public static NetManger GetInstance()
    {
        return _instance ?? (_instance = new NetManger());
    }


    public IEnumerator GetRequest(string uri, System.Action<string> onSuccess, System.Action<string> onFailure)
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

    public IEnumerator PostRequest(string uri, string postData, System.Action<string> onSuccess, System.Action<string> onFailure)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, postData, "application/json"))
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


    public IEnumerator PatchRequest(string uri, string postData, System.Action<string> onSuccess, System.Action<string> onFailure)
    {
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(postData);
        UnityWebRequest www = new UnityWebRequest(uri, "PATCH");
        www.uploadHandler = new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("PATCH request failure");
            onFailure(www.error);
        }
        else
        {
            Debug.Log("PATCH request successful");
            onSuccess(www.downloadHandler.text);
        }
    }
}

