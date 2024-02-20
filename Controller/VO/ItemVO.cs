using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVO : BaseVO
{
    public ItemVO(string nameFile)
    {
        // truyền tên file vào để load lên
        this.LoadData("Item/" + nameFile);
    }
    // lấy data từ Json theo thứ tự 
    public Item GetEntityInfo(int num)
    {
        // trả về 1  đối tượng  trong mảng Json // lấy theo thứ tư 
        return JsonUtility.FromJson<Item>(data.AsArray[num].ToString());
    }
    public int ArrayCount => data.AsArray.Count;
}
