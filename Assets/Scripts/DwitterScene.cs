using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DwitterScene : MonoBehaviour
{

    public GameObject oneComment;
    public GameObject foryouContent;
    public GameObject followContent;

    public GameObject foryouLine;
    public GameObject followLine;
    public GameObject foryouBody;
    public GameObject followBody;

    public GameObject submitPage;
    public TMP_InputField postContent;

    public void onClickBack()
    {
        SceneManager.LoadScene(0);
    }

    public void onClickForyou()
    {
        foryouLine.SetActive(true);
        foryouBody.SetActive(true);
        followLine.SetActive(false);
        followBody.SetActive(false);
    }

    public void onClickFollow()
    {
        foryouLine.SetActive(false);
        foryouBody.SetActive(false);
        followLine.SetActive(true);
        followBody.SetActive(true);
    }

    private void Update()
    {
        var curSwipe = DetectSwipeDirection();
        if (curSwipe >= 0)
        {
            Debug.Log(curSwipe);
            if (curSwipe == 0)
            {
                onClickFollow();
            }
            else if (curSwipe == 1)
            {
                onClickForyou();
            }
        }

    }

    private int DetectSwipeDirection()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDelta = Input.GetTouch(0).deltaPosition;

            if (Mathf.Abs(touchDelta.x) > Mathf.Abs(touchDelta.y))
            {
                if (touchDelta.x < 0)
                {
                    // ◊Ûª¨
                    return 0;
                }
                else if (touchDelta.x > 0)
                {
                    // ”“ª¨
                    return 1;
                }
            }
        }

        // √ª”–ºÏ≤‚µΩ◊Ûª¨ªÚ”“ª¨
        return -1;
    }

    public void OnClickSubmit()
    {
        submitPage.SetActive(true);

    }

    public void OnClickSubmitCancel()
    {
        submitPage.SetActive(false);
    }

    public void OnClickPost()
    {
        var one = Instantiate(oneComment, foryouContent.transform);
        if (postContent.text != "")
        {
            one.GetComponent<SingleTW>().initTW(postContent.text);
            postContent.text = "";
            submitPage.SetActive(false);

        }
    }

}
