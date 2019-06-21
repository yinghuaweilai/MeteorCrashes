using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowUsSceneScript : MonoBehaviour
{
    public Button btn_facebook;
    public Button btn_twitter;
    public Button btn_cancel;

    //设置监听
    void Start()
    {
        btn_facebook.onClick.AddListener(OpenFaceBook);
        btn_twitter.onClick.AddListener(OpenTwitter);
        btn_cancel.onClick.AddListener(Cancel);
    }

    //关闭followus界面
    private void Cancel()
    {
        Destroy(gameObject);
    }

    //打开facebook
    private void OpenTwitter()
    {
        Application.OpenURL("https://www.baidu.com/");
    }

    //打开twitter
    private void OpenFaceBook()
    {
        Application.OpenURL("https://www.baidu.com/");
    }

    //取消监听
    private void OnDestroy()
    {
        btn_facebook.onClick.RemoveListener(OpenFaceBook);
        btn_twitter.onClick.RemoveListener(OpenTwitter);
        btn_cancel.onClick.RemoveListener(Cancel);
    }
}
