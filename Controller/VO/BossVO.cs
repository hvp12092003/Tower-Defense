using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVO : BaseVO
{
    public BossVO()
    {
        // truyền tên file vào để load lên
        this.LoadData("Enemy/BossEnemy");
    }
    // lấy data từ Json theo thứ tự 
    public Enemy GetEntityInfo(int num)
    {
        // trả về 1  đối tượng  trong mảng Json // lấy theo thứ tư 
        return JsonUtility.FromJson<Enemy>(data.AsArray[num-1].ToString());
    }
}
