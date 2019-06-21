using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFactory : MonoBehaviour
{
    public User user;
    public GameObject NuclearExplosion;
    private NuclearExplosion nuc;
    public GameObject FleetDemining;
    private FleetDemining fleet;
    public GameObject Shield;
    private Shield shi;
    public GameObject GravitationalField;
    
    private void Start()
    {
        user = GameObject.Find("GameScene").GetComponent<GameSceneScript>().user;
        nuc = NuclearExplosion.GetComponent<NuclearExplosion>();
        shi = Shield.GetComponent<Shield>();
        fleet = FleetDemining.GetComponent<FleetDemining>();
        InitNuc();
        InitShi();
        InitFleet();
    }

    private void InitNuc()
    {
        nuc.level = user.NuclearExplosion;
        nuc.cd = SkillDict.NucCd[nuc.level - 1];
        nuc.damage = SkillDict.NucDamage[nuc.level - 1];
    }

    private void InitShi()
    {
        shi.level = user.Shield;
        shi.cd = SkillDict.ShiCd[shi.level - 1];
        shi.duration = SkillDict.Shiduration[shi.level - 1];
    }

    private void InitFleet()
    {
        fleet.level = user.FleetDemining;
        fleet.cd = SkillDict.FleetCd[fleet.level - 1];
        fleet.damage = SkillDict.FleetDamage[fleet.level - 1];
    }
}
