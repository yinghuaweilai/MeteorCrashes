using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using System.IO;

// 挂载到场景物体
public class UserProtobuf
{
    private static UserProtobuf _instance;  // 单例
    public static UserProtobuf Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UserProtobuf();
            }
            return _instance;
        }
    }

    /* UserSerializer(UserDeserialization()); // 序列化
     * UserDeserialization();  // 反序列化
     * upgrade("GravitationalField");  // 升级
    */

    /// <summary>
    /// 升级某个道具并序列化到本地
    /// </summary>
    /// <param name="name">升级的名字</param>
    /// /// <param name="name">User对象</param>
    public void upgrade(string name, User user = null)
    {
        // user 为空，则反序列化本地数据
        if (user == null)
            user = UserDeserialization();
        switch (name)
        {
            case "Gold":
                user.Gold += 1;
                break;
            case "NuclearExplosion":
                user.NuclearExplosion += 1;
                break;
            case "FleetDemining":
                user.FleetDemining += 1;
                break;
            case "Shield":
                user.Shield += 1;
                break;
            case "GravitationalField":
                user.GravitationalField += 1;
                break;
            case "EarthLevel":
                user.EarthLevel += 1;
                break;
            case "Damage":
                user.Damage += 1;
                break;
            case "Scope":
                user.Scope += 1;
                break;
            default:
                return;
                break;
        }
        UserSerializer(user);
        Debug.Log(name + "升级到：" + user.GravitationalField);
    }

    // 序列化
    public void UserSerializer(User user)
    {
        using (var fs = File.Create(Application.dataPath + "/user.bin"))
        {
            Serializer.Serialize<User>(fs, user);
        }
    }

    // 反序列化
    public User UserDeserialization()
    {
        User user = null;

        // 如果文件不存在，初始化数据并且序列化
        if (!File.Exists(Application.dataPath + "/user.bin"))
        {
            user = new User();
            UserSerializer(user);
        }
        // 反序列化
        using (var fs = File.OpenRead(Application.dataPath + "/user.bin"))
        {
            user = Serializer.Deserialize<User>(fs);
        }
        return user;
    }
}