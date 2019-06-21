using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour
{
    public Button btn_Start;
    public Button btn_Store;
    public Button btn_FollowUs;
    public Button btn_Mute;//静音按钮
    public Button btn_NotMute;//不静音按钮

    private void Start()
    {
        //设置监听
        btn_Start.onClick.AddListener(StartOnClicked);
        btn_Store.onClick.AddListener(OpenStore);
        btn_FollowUs.onClick.AddListener(OpenFollowUsScene);
        btn_Mute.onClick.AddListener(MusicMute);
        btn_NotMute.onClick.AddListener(MusicNotMute);

        //初始获取历史记录是否静音
        if (PlayerPrefs.GetInt("ismute") == 1)
        {
            BGMHolderScript.Instance.isMute = false;
            btn_NotMute.gameObject.SetActive(false);
            btn_Mute.gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("ismute") == 0)
        {
            BGMHolderScript.Instance.isMute = true;
            btn_NotMute.gameObject.SetActive(true);
            btn_Mute.gameObject.SetActive(false);
        }
        else
        {
            BGMHolderScript.Instance.isMute = false;
            PlayerPrefs.SetInt("ismute", 1);
            btn_NotMute.gameObject.SetActive(false);
            btn_Mute.gameObject.SetActive(true);
        }
    }

    //不静音
    private void MusicNotMute()
    {
        btn_NotMute.gameObject.SetActive(false);
        btn_Mute.gameObject.SetActive(true);
        PlayerPrefs.SetInt("ismute", 1);
        BGMHolderScript.Instance.isMute = false;
    }

    //静音
    private void MusicMute()
    {
        btn_NotMute.gameObject.SetActive(true);
        btn_Mute.gameObject.SetActive(false);
        PlayerPrefs.SetInt("ismute", 0);
        BGMHolderScript.Instance.isMute = true;
    }

    //打开OpenUs界面
    private void OpenFollowUsScene()
    {
        //Tools.CreateUIPanel("FollowUsScene");
        GameObject followUsScene = Instantiate(Resources.Load<GameObject>("Prefabs/FollowUsScene"));
        followUsScene.transform.SetParent(transform, false);
        followUsScene.name = "FollowUsScene";
    }

    //打开商店
    private void OpenStore()
    {
        //Tools.CreateUIPanel("StoreScene");
        GameObject storeScene = Instantiate(Resources.Load<GameObject>("Prefabs/StoreScene"));
        storeScene.transform.SetParent(transform, false);
        storeScene.name = "StoreScene";
    }

    //进入游戏界面
    private void StartOnClicked()
    {
        Tools.DeleteUIPanel("StartScene");
        Tools.CreateUIPanel("GameScene");
    }

    //取消监听
    private void OnDestroy()
    {
        btn_Start.onClick.RemoveListener(StartOnClicked);
        btn_Store.onClick.RemoveListener(OpenStore);
        btn_FollowUs.onClick.RemoveListener(OpenFollowUsScene);
        btn_Mute.onClick.RemoveListener(MusicMute);
        btn_NotMute.onClick.RemoveListener(MusicNotMute);
    }
}
