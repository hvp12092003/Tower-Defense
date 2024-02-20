using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using LTAUnityBase.Base.DesignPattern;
public class MoveMainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject Shop;
    public GameObject ChooseMap;
    public GameObject Updated;
    public GameObject Register;
    public GameObject Setting;

    public GameObject buttonsSocialL;
    public GameObject buttonsSocialR;
    public GameObject buttonPlay;
    public GameObject buttonRegister;
    public GameObject buttonSetting;

    //register
    public GameObject menuRigister;

    // setting
    public GameObject menuSetting;

    //chooseLvMap
    public GameObject menuChooseLvMap;
    public GameObject buttonChooseLvMap;

    //shop
    public GameObject shopJe;
    public GameObject shopItem;
    public GameObject btExit;
    public GameObject btInforItem;

    //update
    public GameObject MenuUpdate;

    bool OffMain = false;
    bool OfShop = false;
    bool OffChooseMap = false;
    bool OffUpdated = false;
    bool OffRegister = false;
    bool OffSetting = false;

    float count = 1;
    public void OnMenuUpdate()
    {
        OffUpdated = false;
        Updated.SetActive(true);
        MenuUpdate.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
    }
    public void OffMenuUpdate()
    {
        MenuUpdate.transform.DOLocalMove(new Vector3(0, 1300, 0), 0.5f);
        OffUpdated = true;

    }


    public void OnShop()
    {
        OfShop = false;
        Shop.SetActive(true);
        shopJe.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        shopItem.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        btExit.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        btInforItem.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
    }
    public void OffShop()
    {
        shopJe.transform.DOLocalMove(new Vector3(0, 1300, 0), 0.5f);
        shopItem.transform.DOLocalMove(new Vector3(-800, 0, 0), 0.5f);
        btExit.transform.DOLocalMove(new Vector3(800, 0, 0), 0.5f);
        btInforItem.transform.DOLocalMove(new Vector3(0, -800, 0), 0.5f);
        OfShop = true;
    }


    public void OffMenuMain()
    {
        buttonsSocialL.transform.DOLocalMove(new Vector3(-500, 0, 0), 0.5f);
        buttonsSocialR.transform.DOLocalMove(new Vector3(500, 0, 0), 0.5f);
        buttonSetting.transform.DOLocalMove(new Vector3(0, 600, 0), 0.5f);
        buttonRegister.transform.DOLocalMove(new Vector3(0, 1500, 0), 0.5f);
        buttonPlay.transform.DOLocalMove(new Vector3(0, 1500, 0), 0.5f);
        OffMain = true;
    }
    public void OnMenuMain()
    {
        OffMain = false;
        Main.SetActive(true);
        buttonsSocialL.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        buttonsSocialR.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        buttonSetting.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        buttonRegister.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        buttonPlay.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
    }

    public void OnMenuRegister()
    {
        OffRegister = false;
        Register.SetActive(true);
        menuRigister.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
    }
    public void OffMenuRegister()
    {
        menuRigister.transform.DOLocalMove(new Vector3(0, 1300, 0), 0.5f);
        OffRegister = true;
    }
    public void OnMenuSetting()
    {
        OffSetting = false;
        Setting.SetActive(true);
        menuSetting.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
    }
    public void OffMenuSettingr()
    {
        menuSetting.transform.DOLocalMove(new Vector3(0, 1300, 0), 0.5f);
        OffSetting = true;

    }
    public void OffMenuChooseLvMap()
    {
        menuChooseLvMap.transform.DOLocalMove(new Vector3(0, 1300, 0), 0.5f);
        buttonChooseLvMap.transform.DOLocalMove(new Vector3(700, 0, 0), 0.5f);
        OffChooseMap = true;

    }
    public void OnMenuChooseLvMap()
    {
        OffChooseMap = false;
        ChooseMap.SetActive(true);
        menuChooseLvMap.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
        buttonChooseLvMap.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
    }
    public void Update()
    {
        if (OffChooseMap)
        {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                OffChooseMap = false;
                ChooseMap.SetActive(false);
            }
        }
        else if (OffMain)
        {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                Main.SetActive(false);
                OffMain = false;
            }
        }
        else if (OffRegister)
        {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                OffRegister = false;
                Register.SetActive(false);
            }
        }
        else if (OffSetting)
        {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                Setting.SetActive(false);
                OffSetting = false;
            }
        }
        else if (OfShop)
        {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                OfShop = false;
                Shop.SetActive(false);
            }
        }
        else if (OffUpdated)
        {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                Updated.SetActive(false);
                OffUpdated = false;
            }
        }
        else
        {
            count = 1;
        }

    }
}
public class MoveMenu : SingletonMonoBehaviour<MoveMainMenu> { }
