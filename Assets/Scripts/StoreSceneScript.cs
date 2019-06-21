using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSceneScript : MonoBehaviour
{
    public Button btn_close;

    public Button btn_buyNuclearExplosion;
    public Button btn_buyFleetDemining;
    public Button btn_buyShield;
    public Button btn_buyGravitationalField;
    public Button btn_buyEarthLevel;
    public Button btn_buyDamage;

    //设置监听
    void Start()
    {
        btn_close.onClick.AddListener(CloseStore);

        btn_buyNuclearExplosion.onClick.AddListener(BuyNuclearExplosion);
        btn_buyFleetDemining.onClick.AddListener(BuyFleetDemining);
        btn_buyShield.onClick.AddListener(BuyShield);
        btn_buyGravitationalField.onClick.AddListener(BuyGravitationalField);
        btn_buyEarthLevel.onClick.AddListener(BuyEarthLeve);
        btn_buyDamage.onClick.AddListener(BuyDamage);
    }
    
    //买核爆
    private void BuyNuclearExplosion()
    {
        Debug.Log("买核爆");
    }

    //买舰队扫雷
    private void BuyFleetDemining()
    {
        Debug.Log("买舰队扫雷");
    }

    //买护盾
    private void BuyShield()
    {
        Debug.Log("买护盾");
    }

    //买引力场
    private void BuyGravitationalField()
    {
        Debug.Log("买引力场");
    }

    //买地球等级
    private void BuyEarthLeve()
    {
        Debug.Log("买地球等级");
    }

    //买手势滑动伤害
    private void BuyDamage()
    {
        Debug.Log("买手势滑动伤害");
    }
    
    //关闭商店
    private void CloseStore()
    {
        Destroy(gameObject);
    }

    //取消监听
    private void OnDestroy()
    {
        btn_close.onClick.RemoveListener(CloseStore);

        btn_buyNuclearExplosion.onClick.RemoveListener(BuyNuclearExplosion);
        btn_buyFleetDemining.onClick.RemoveListener(BuyFleetDemining);
        btn_buyShield.onClick.RemoveListener(BuyShield);
        btn_buyGravitationalField.onClick.RemoveListener(BuyGravitationalField);
        btn_buyEarthLevel.onClick.RemoveListener(BuyEarthLeve);
        btn_buyDamage.onClick.RemoveListener(BuyDamage);
    }

}
