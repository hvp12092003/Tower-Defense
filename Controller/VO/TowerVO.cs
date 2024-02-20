using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerVO : BaseVO
{
    public TowerVO(string nameFile)
    {
        // truyền tên file vào để load lên
        //  this.LoadData("ArcherTower");
        this.LoadData("Tower/" + nameFile);
    }
    // lấy data từ Json theo thứ tự 
    public Tower GetEntityInfo(int num)
    {
        // trả về 1  đối tượng  trong mảng Json // lấy theo thứ tư 
        return JsonUtility.FromJson<Tower>(data.AsArray[num].ToString());
    }
    public int ArrayCount => data.AsArray.Count;
}
