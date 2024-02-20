using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInMapVO : BaseVO
{
    public EnemyInMapVO(int map)
    {        
        // truyền tên file vào để load lên
        this.LoadData("DataMap/EnemyMap" + (map).ToString());
    }
    // lấy data từ Json theo thứ tự 
    public TypeEnemy GetEntityInfo(int num)
    {
        // trả về 1  đối tượng  trong mảng Json // lấy theo thứ tư 
        return JsonUtility.FromJson<TypeEnemy>(data.AsArray[num].ToString());
    }
    public int ArrayCount => data.AsArray.Count;
}
