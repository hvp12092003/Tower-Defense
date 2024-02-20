using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
public class BaseVO
{
    // cái biến để lưu hết chuỗi trong JSon
    protected JSONNode data;

    // hàm để load data từ json lên (truyền tên file vào)
    protected void LoadData(string FileName)
    {
        // gắn abc là kiểu text để luu hết các kí tự trong file Json //(truyền vào cái đường dẫn bắt đầu từ file "resources")
        TextAsset abc = Resources.Load<TextAsset>("Data/" + FileName);
        // lưu hết dữ liệu vào biến data
        data = JSONNode.Parse(abc.text)["data"];
    }
}
