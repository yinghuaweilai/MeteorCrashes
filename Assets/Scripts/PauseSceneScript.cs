using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseSceneScript : MonoBehaviour
{
    public Button btn_continue;
    public Button btn_restart;
    public Button btn_backToMenu;

    //设置监听
    void Start()
    {
        btn_continue.onClick.AddListener(ContinueGame);
        btn_restart.onClick.AddListener(RestartGame);
        btn_backToMenu.onClick.AddListener(BackToMenu);
    }

    //回到主界面
    private void BackToMenu()
    {
        Time.timeScale = 1;
        Tools.CreateUIPanel("StartScene");
        Destroy(transform.parent.gameObject);
    }

    //重新开始游戏
    private void RestartGame()
    {
        Time.timeScale = 1;
        Tools.CreateUIPanel("GameScene");
        Destroy(transform.parent.gameObject);
    }

    //继续游戏
    private void ContinueGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    //取消监听
    private void OnDestroy()
    {
        btn_continue.onClick.RemoveListener(ContinueGame);
        btn_restart.onClick.RemoveListener(RestartGame);
        btn_backToMenu.onClick.RemoveListener(BackToMenu);
    }
}
