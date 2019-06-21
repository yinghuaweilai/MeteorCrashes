using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneScript : MonoBehaviour
{
    public Button btn_restart;
    public Button btn_backToMenu;
    public Button btn_upgrade;

    //设置监听
    void Start()
    {
        btn_restart.onClick.AddListener(Restart);
        btn_backToMenu.onClick.AddListener(BackToMenu);
        btn_upgrade.onClick.AddListener(Upgrade);
    }

    //升级（打开商店界面）
    private void Upgrade()
    {
        GameObject storeScene = Instantiate(Resources.Load<GameObject>("Prefabs/StoreScene"));
        storeScene.transform.SetParent(transform, false);
        storeScene.name = "StoreScene";
    }

    //回到主界面
    private void BackToMenu()
    {
        Tools.CreateUIPanel("StartScene");
        Destroy(transform.parent.gameObject);
    }

    //重新开始
    private void Restart()
    {
        Tools.CreateUIPanel("GameScene");
        Destroy(transform.parent.gameObject);
    }

    //取消监听
    private void OnDestroy()
    {
        btn_restart.onClick.RemoveListener(Restart);
        btn_backToMenu.onClick.RemoveListener(BackToMenu);
        btn_upgrade.onClick.RemoveListener(Upgrade);
    }
}
