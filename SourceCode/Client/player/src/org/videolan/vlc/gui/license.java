package org.videolan.vlc.gui;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;

import android.content.SharedPreferences.Editor;
import android.os.Bundle;
import android.util.Log;

public class license extends Activity {
	
	  public static String PreferenceFileName = "license";//�洢��Ȩ����ļ���,ÿ�λ��һ����Ȩ�룬������ӵ�����ļ�����
	  @SuppressWarnings("deprecation")
		public static int MODE = Context.MODE_WORLD_READABLE +
	            Context.MODE_WORLD_WRITEABLE;
	  public void onCreate(Bundle savedInstanceState) { 
	        super.onCreate(savedInstanceState);      
	        Log.e("license", "onCreate"); 
	    } 

	  //��ȡ��Ȩ��
		public   String loadSharedPreferences(String videoid)
		{
			/*
			SharedPreferences sharedPreferences = getSharedPreferences
					(PreferenceFileName,MODE);
			System.out.println("all = "+sharedPreferences.getAll());
			String sn = sharedPreferences.getString(videoid,"none");//��������ڣ�����
			System.out.println(videoid+":sn = "+sn);
			return sn;
			*/
			return "sn";
		}
		//�洢��Ȩ��
		public   void saveSharedPreferences(String videoid,String sn)
		{
			SharedPreferences sharedPreferences= getSharedPreferences
					(PreferenceFileName,MODE);
			SharedPreferences.Editor editor = sharedPreferences.edit();
			editor.putString(videoid, sn);
			editor.commit();
		}

}
