package org.videolan.vlc.gui;

import org.videolan.libvlc.LibVLC;
import org.videolan.libvlc.LibVlcException;
import org.videolan.vlc.R;
import org.videolan.vlc.Util;
import org.videolan.vlc.interfaces.ISortable;

import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.JavascriptInterface;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.support.v4.app.Fragment;

import com.actionbarsherlock.app.SherlockListFragment;


public class VideoWebIndexViewFragment extends Fragment  {
	private LibVLC mLibVLC;
	
    public final static String TAG = "VLC/VideoWebIndexViewFragment";
    public VideoWebIndexViewFragment() {
    	
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
       // t.loadData(Util.readAsset("videowebindex.htm", ""), "text/html", "UTF8");
       String serverip="http://192.168.1.127:81";
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
		String url=serverip+"/index.aspx";
		web01.loadUrl(url);
		
        return v;
    }
    
    public void startdownloadvideo(String btn)//@JavascriptInterface  ÍøÒ³½Ó¿Úº¯Êý
	{
    	Log.d("startdownloadvideo",btn); 
    	
		mLibVLC.downloadfilelist=btn;
	
	
	//	intent = new Intent(MainActivity.this,VedioActivity.class);
	//	intent.putExtra("String", btn);
	//	startActivity(intent);
	//	 videostate=1;
		 	 
		
	}

}
