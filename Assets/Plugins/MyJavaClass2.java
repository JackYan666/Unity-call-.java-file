package com.unity.androidplugin;

import android.widget.Toast;
import android.content.Context;


public class MyJavaClass2 {

	//方式二 unity设置context
    public static void ShowToast(String info,Context context)
    {
        Toast.makeText(context,info,Toast.LENGTH_LONG).show();
    }
}
