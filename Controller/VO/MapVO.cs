using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapVO : BaseVO
{
    public MapVO()
    {
        // truyền tên file vào để load lên
        this.LoadData("DataMap/Map");
    }
    // lấy data từ Json theo thứ tự 
    public DataMap GetEntityInfo(int num)
    {
        // trả về 1  đối tượng  trong mảng Json // lấy theo thứ tư 
        return JsonUtility.FromJson<DataMap>(data.AsArray[num].ToString());
    }

}
