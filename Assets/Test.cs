using UnityEngine;
using System;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text Log;

    AndroidJavaClass jc_UnityPlayer;
    AndroidJavaObject jo_UnityActivity;

    AndroidJavaObject jo_MyJavaClass1;
    AndroidJavaObject jo_MyJavaClass2;
    AndroidJavaObject jo_MathClass;
    // Start is called before the first frame update
    void Start()
    {
        jc_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        jo_UnityActivity = jc_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        jo_MyJavaClass1 = new AndroidJavaObject("com.unity.androidplugin.MyJavaClass1");
        jo_MyJavaClass1.CallStatic("SetContext", jo_UnityActivity);

        jo_MyJavaClass2 = new AndroidJavaObject("com.unity.androidplugin.MyJavaClass2");

        jo_MathClass = new AndroidJavaObject("com.unity.androidplugin.MathClass");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.touchCount == 1)
        {
            UnityCallJava("单击");
        }
        else if (Input.GetMouseButtonDown(0) && Input.touchCount == 2)
        {
            UnityCallJava("双击");
        }
    }

    public void Method1()
    {
        try
        {
            jo_MyJavaClass1.CallStatic("ShowToast", "方式一");
            Log.text = "方式一";
        }
        catch (Exception e)
        {
            Log.text = e.Message;
        }
    }
    public void Method2()
    {
        UnityCallJava("方式二");

    }
    void UnityCallJava(string msg)
    {
        try
        {
            Log.text = msg;
            jo_MyJavaClass2.CallStatic("ShowToast", msg, jo_UnityActivity);
        }
        catch (Exception e)
        {
            Log.text = e.Message;
        }
    }

    public void MathTest()
    {
        try
        {
            int result = jo_MathClass.CallStatic<int>("Add", 2, 3);
            Log.text = result.ToString();
        }
        catch (Exception e)
        {
            Log.text = e.Message;
        }
    }
}
