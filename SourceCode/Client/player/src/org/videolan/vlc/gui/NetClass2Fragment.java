package org.videolan.vlc.gui;

import org.videolan.libvlc.LibVLC;
import org.videolan.libvlc.LibVlcException;
import org.videolan.vlc.R;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.JavascriptInterface;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;

import org.videolan.vlc.gui.MainActivity;
import org.videolan.vlc.gui.SidebarAdapter.SidebarEntry;

public class NetClass2Fragment extends Fragment  {	
	 
	private LibVLC mLibVLC;
	public static int vidnum; 
	
    public final static String TAG = "VLC/VideoWebIndexViewFragment";
   
    public NetClass2Fragment() {
    	
    	try {
	            mLibVLC = LibVLC.getInstance();
	        } catch (LibVlcException e) {
	            Log.d(TAG, "LibVlcException encountered in VideoWebIndexViewFragment", e);
	            return;
	        }

    }
    @JavascriptInterface
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
    	
    	Log.e(TAG, "go to video web!");
        super.onCreateView(inflater, container, savedInstanceState);
        View v = inflater.inflate(R.layout.videowebindex, container, false);
        WebView web01 = (WebView)v.findViewById(R.id.webview1);
       // t.loadData(Util.readAsset("videowebindex.htm", ""), "textml", "UTF8");
      
       WebSettings webSettings = null;
       webSettings = web01.getSettings();
		 
		webSettings.setJavaScriptEnabled(true);
		webSettings.setJavaScriptCanOpenWindowsAutomatically(true);
		web01.addJavascriptInterface(this,"android");
		int   screenDensity   = getResources().getDisplayMetrics(). densityDpi ; 
  	    WebSettings.ZoomDensity   zoomDensity   = WebSettings.ZoomDensity. MEDIUM ; 
		webSettings.setUseWideViewPort(true); 
		webSettings.setLoadWithOverviewMode(true); 
		webSettings.setCacheMode(WebSettings.LOAD_NO_CACHE);
		web01.setWebViewClient(new WebViewClient(){
			  @Override
            public boolean shouldOverrideUrlLoading(WebView view, String url) {
                     // TODO Auto-generated method stub
                     view.loadUrl(url);
                     return true;
             }});
		String url= MainActivity.serverip+"/index.aspx";
		web01.loadUrl(url);
		
        return v;
    }
    public void downloadingvideomark() 
    {
    //	MainActivity.downloadingmark=1;//表示有文件需要下载
    }
    public void opennetclass(String btn,int num)//@JavascriptInterface  网页接口函数
	{
    	vidnum=num;
    	((MainActivity) MainActivity.mContext).sendHandleMessage(btn);
    }

    public String getFileName(String pathandname){   
        
        int start=pathandname.lastIndexOf("/");   
        int end=pathandname.lastIndexOf(".");   //不包括后缀名
        
        end=pathandname.length();//包括后缀名
        Log.d("count", "end="+end);
        if(start!=-1 && end!=-1){   
             return pathandname.substring(start+1,end);     
          }else{   
             return null;   
         }   
             
  	   }  

}
