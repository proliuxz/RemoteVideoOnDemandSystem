package org.videolan.vlc.gui;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;

import android.content.SharedPreferences.Editor;
import android.os.Bundle;
import android.util.Log;

public class license extends Activity {
	
	  public static String PreferenceFileName = "license";//存储授权码的文件名,每次获得一个授权码，都会添加到这个文件夹中
	  @SuppressWarnings("deprecation")
		public static int MODE = Context.MODE_WORLD_READABLE +
	            Context.MODE_WORLD_WRITEABLE;
	  public void onCreate(Bundle savedInstanceState) { 
	        super.onCreate(savedInstanceState);      
	        Log.e("license", "onCreate"); 
	    } 

	  //获取授权码
		public   String loadSharedPreferences(String videoid)
		{
			/*
			SharedPreferences sharedPreferences = getSharedPreferences
					(PreferenceFileName,MODE);
			System.out.println("all = "+sharedPreferences.getAll());
			String sn = sharedPreferences.getString(videoid,"none");//如果不存在，返回
			System.out.println(videoid+":sn = "+sn);
			return sn;
			*/
			return "sn";
		}
		//存储授权码
		public   void saveSharedPreferences(String videoid,String sn)
		{
			SharedPreferences sharedPreferences= getSharedPreferences
					(PreferenceFileName,MODE);
			SharedPreferences.Editor editor = sharedPreferences.edit();
			editor.putString(videoid, sn);
			editor.commit();
		}

}
