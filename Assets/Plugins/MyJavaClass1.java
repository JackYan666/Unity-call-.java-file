package com.unity.androidplugin;

import android.widget.Toast;
import android.content.Context;

public class MyJavaClass1 {

  //方式一 java设置Context
    public static Context ShowContext = null;
	public static void SetContext(Context con)
	{
		ShowContext = con;
	}
	 public static void ShowToast(String info)
    {
        Toast.makeText(ShowContext,info,Toast.LENGTH_LONG).show();
    }
}

