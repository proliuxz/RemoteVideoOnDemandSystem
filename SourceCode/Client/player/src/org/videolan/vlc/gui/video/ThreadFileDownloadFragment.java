package org.videolan.vlc.gui.video;

import java.io.File;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;
import java.util.HashMap;
import java.util.List;
import java.util.concurrent.BrokenBarrierException;
import java.util.concurrent.CyclicBarrier;

import org.videolan.android.ui.SherlockGridFragment;
import org.videolan.libvlc.LibVLC;
import org.videolan.libvlc.Media;
import org.videolan.vlc.AudioServiceController;
import org.videolan.vlc.MediaDatabase;
import org.videolan.vlc.MediaGroup;
import org.videolan.vlc.MediaLibrary;
import org.videolan.vlc.R;
import org.videolan.vlc.Thumbnailer;
import org.videolan.vlc.Util;
import org.videolan.vlc.VlcRunnable;
import org.videolan.vlc.WeakHandler;
import org.videolan.vlc.gui.CommonDialogs;
import org.videolan.vlc.gui.HistoryAdapter;
import org.videolan.vlc.gui.MainActivity;
import org.videolan.vlc.gui.audio.AudioPlayerFragment;

import org.videolan.vlc.interfaces.ISortable;

import com.actionbarsherlock.app.SherlockListFragment;

import android.annotation.TargetApi;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.res.Configuration;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.os.SystemClock;
import android.support.v4.app.FragmentActivity;
import android.util.DisplayMetrics;
import android.util.Log;
import android.view.ContextMenu;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.View.OnClickListener;
import android.webkit.WebView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.PopupMenu;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.PopupMenu.OnMenuItemClickListener;


public class ThreadFileDownloadFragment extends SherlockListFragment  {
	
	private TextView downloadurl;
	private int downloadnum;
	private Button downloadbutton;
	private ProgressBar downloadProgressBar;
	private TextView downloadinfo;
	private int downloadedSize = 0;
	private int fileSize = 0;
	
	private long downloadtime;
	 protected LinearLayout mLayoutFlipperLoading;
	    protected TextView mTextViewNomedia;
	    private Thumbnailer mThumbnailer;

	 public final static String TAG = "VLC/ThreadFileDownloadFragment";

	    private ThreadFileDownloadAdapter mThreadFileDownloadAdapter;

	    /* All subclasses of Fragment must include a public empty constructor. */
	    public ThreadFileDownloadFragment() { }

	    @Override
	    public void onCreate(Bundle savedInstanceState) {
	        super.onCreate(savedInstanceState);

	      mThreadFileDownloadAdapter = new ThreadFileDownloadAdapter();
	        Log.d(TAG, "onCreate ");
	    }

	    @Override
	    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
	    {
	    	Log.d(TAG, "onCreateView");
	       View v = inflater.inflate(R.layout.download_list, container, false);
	        setListAdapter(mThreadFileDownloadAdapter);
	        final ListView listView = (ListView)v.findViewById(android.R.id.list);
	        registerForContextMenu(listView);
	        return v;
	  
	    }

	    @Override
	    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo) {
	    	Log.d(TAG, "onCreateContextMenu");
	        MenuInflater menuInflater = getActivity().getMenuInflater();
	        menuInflater.inflate(R.menu.history_view, menu);
	    }

	    @Override
	    public void onListItemClick(ListView l, View v, int p, long id) {
	        playListIndex(p);
	    }

	    private void playListIndex(int position) {
	        AudioServiceController audioController = AudioServiceController.getInstance();

	        LibVLC.getExistingInstance().setMediaList();
	        audioController.playIndex(position);//≤•∑≈ ”∆µ
	       AudioPlayerFragment.start(getActivity());
	    }

	    @Override
	    public boolean onContextItemSelected(MenuItem item) {
	    	Log.d(TAG, "onContextItemSelected");
	        if(!getUserVisibleHint()) return super.onContextItemSelected(item);

	        AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
	        if(info == null) // info can be null
	            return super.onContextItemSelected(item);
	        int id = item.getItemId();

	        if(id == R.id.history_view_play) {
	            playListIndex(info.position);
	            return true;
	        } else if(id == R.id.history_view_delete) {
	            LibVLC.getExistingInstance().getPrimaryMediaList().remove(info.position);
	            mThreadFileDownloadAdapter.refresh();
	            return true;
	        }
	        return super.onContextItemSelected(item);
	    }

	    public void refresh() {
	        Log.d(TAG, "Refreshing view!");
	        if( mThreadFileDownloadAdapter != null )
	        	mThreadFileDownloadAdapter.refresh();
	    }
	}
