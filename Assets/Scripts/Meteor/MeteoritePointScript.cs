using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 陨石生成点的管理类
/// </summary>
public class MeteoritePointScript : MonoBehaviour
{
    public float speed;   // 下落速度累加值
    public float flintiness;  // 坚硬度累加值
    public float frequency;   // 多少秒掉落一个陨石
    public GameObject MeteorPrefab; // 陨石预制体
    public GameObject MeteorPoint;  // 默认掉落点
    public List<GameObject> Meteors;    // 所有的陨石

    void Start()
    {
        Init();
    }

    private void Init()
    {
        speed = 1f;
        flintiness = 1f;
        frequency = 3f;
    }

    void Update()
    {
        Fire(frequency);
    }

    float nextFire = 0;
    /// <summary>
    /// 生成陨石
    /// </summary>
    /// <param name="frequency">生成间隔</param>
    private void Fire(float frequency)
    {
        if (Time.time < nextFire)
        {
            return;
        }
        else if (Time.time >= nextFire)
        {
            nextFire = Time.time + frequency;
            CreateMeteor();
        }
    }

    // 生成陨石
    public void CreateMeteor()
    {
        GameObject prefab = MeteorPrefab;
        prefab.GetComponent<MeteorScript>().meteoritePointScript = this;
        GameObject obj = GameObject.Instantiate(prefab, MeteorPoint.transform);
        obj.transform.SetParent(transform, false);
        Meteors.Add(obj);
    }

    public void RemoveMeteor(GameObject obj)
    {
        Meteors.Remove(obj);
        Destroy(obj);
    }
}
