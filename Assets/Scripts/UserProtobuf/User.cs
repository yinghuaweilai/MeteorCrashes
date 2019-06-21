using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf; // 需要import protobuf-net.dll,将protobuf-net.dll拖拽到工程

[ProtoContract]
public class User
{
    // 玩家ID序列
    [ProtoMember(1)]
    public int ID { get; set; }
    // 金币数
    [ProtoMember(2)]
    public int Gold { get; set; }
    // 核爆
    [ProtoMember(3)]
    public int NuclearExplosion{ get; set; }
    // 舰队扫雷
    [ProtoMember(4)]
    public int FleetDemining { get; set; }
    // 护盾
    [ProtoMember(5)]
    public int Shield { get; set; }
    // 引力场
    [ProtoMember(6)]
    public int GravitationalField { get; set; }
    // 地球等级(血量相关，入场加速)
    [ProtoMember(7)]
    public int EarthLevel { get; set; }
    // 手势滑动伤害
    [ProtoMember(8)]
    public int Damage { get; set; }
    // 手势滑动范围
    [ProtoMember(9)]
    public int Scope { get; set; }

    public User()
    {
        ID = 1;  // 玩家ID序列用作预留
        Gold = 0;
        NuclearExplosion = 1;
        FleetDemining = 1;
        Shield = 1;
        GravitationalField = 1;
        EarthLevel = 1;
        Damage = 1;
        Scope = 1;
    }
}
