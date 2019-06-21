using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 工具类
public static class Tools
{
    private static Transform uiParent;
    /// <summary>
    /// UI的父物体
    /// </summary>
    public static Transform UIParent
    {
        get
        {
            if (uiParent == null)
                uiParent = GameObject.Find("UIParent/Canvas").transform;
            return uiParent;
        }
    }

    /// <summary>
    /// 创建UI面板
    /// </summary>
    /// <param name="panelName">面板名字</param>
    /// <returns>创建面板的实例</returns>
    public static GameObject CreateUIPanel(string panelName)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/"+ panelName);
        if (prefab == null)
        {
            Debug.LogWarning("这个 " + panelName + " 面板不存在");
            return null;
        }
        else
        {
            GameObject panel = UnityEngine.Object.Instantiate<GameObject>(prefab);
            panel.name = panelName;
            panel.transform.SetParent(UIParent, false);
            Debug.Log("创建面板：" + panelName);
            return panel;
        }
    }

    /// <summary>
    /// 删除面板
    /// </summary>
    /// <param name="panelName">面板名字</param>
    public static void DeleteUIPanel(string panelName)
    {
        GameObject panel = GameObject.Find(panelName);
        if (panel == null)
        {
            Debug.LogWarning("这个 " + panelName + " 面板不存在");
            return;
        }
        else
        {
            GameObject.Destroy(panel);
            Debug.Log("销毁面板：" + panelName);
        }
    }

    public static double[] NormalDistribution()
    {

        System.Random rand = new System.Random();
        double[] y;
        double u1, u2, v1 = 0, v2 = 0, s = 0, z1 = 0, z2 = 0;
        while (s > 1 || s == 0)
        {
            u1 = rand.NextDouble();
            u2 = rand.NextDouble();
            v1 = 2 * u1 - 1;
            v2 = 2 * u2 - 1;
            s = v1 * v1 + v2 * v2;
        }
        z1 = Math.Sqrt(-2 * Math.Log(s) / s) * v1;
        z2 = Math.Sqrt(-2 * Math.Log(s) / s) * v2;
        y = new double[] { z1, z2 };
        return y; //返回两个服从正态分布N(0,1)的随机数z0 和 z1
    }

    /// <summary>
    /// 正太分布的随机函数，生成数在-2~2之间
    /// </summary>
    public static float Random()
    {
        int random = UnityEngine.Random.Range(0,2);
        double[] y = NormalDistribution();
        if (random == 0)
        {
            return (float)y[0];
        }else
        {
            return (float)y[1];
        }
    }

    /// <summary>
    /// 相交运算
    /// </summary>
    /// <param name="objPos">物体坐标</param>
    /// <param name="objscale">物体大小比（宽高固定100）</param>
    /// <param name="mousePos">鼠标坐标</param>
    /// <param name="width">碰撞宽度</param>
    /// <returns></returns>
    public static bool Intersect(Vector2 objPos, float objscale, Vector2 mousePos, float width)
    {
        double x = objPos.x - mousePos.x;
        double y = objPos.y - mousePos.y;
        double distanceMax = Math.Sqrt(x * x + y * y);
        if (distanceMax <= objscale * 100 + width)
            return true;
        else
            return false;
    }


}
