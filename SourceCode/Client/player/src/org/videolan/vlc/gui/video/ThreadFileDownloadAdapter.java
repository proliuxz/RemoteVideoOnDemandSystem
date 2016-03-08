package org.videolan.vlc.gui.video;

import java.io.File;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.protocol.HTTP;
import org.apache.http.util.EntityUtils;
import org.json.JSONObject;
import org.videolan.libvlc.EventHandler;
import org.videolan.libvlc.LibVLC;
import org.videolan.libvlc.LibVlcException;
import org.videolan.libvlc.Media;
import org.videolan.vlc.R;
import org.videolan.vlc.VLCApplication;
import org.videolan.vlc.WeakHandler;
import org.videolan.vlc.gui.DirectoryAdapter;
import org.videolan.vlc.gui.MainActivity;
import org.videolan.vlc.gui.license;
import org.videolan.vlc.gui.audio.AudioUtil;
import org.videolan.vlc.gui.video.MediaInfoAdapter.ViewHolder;
import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.os.SystemClock;
import android.telephony.TelephonyManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.View.OnClickListener;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.app.AlertDialog; 



public class ThreadFileDownloadAdapter extends BaseAdapter{
	 public final static String TAG = "VLC/ThreadFileDownloadAdapter";

	    private LayoutInflater mInflater;
	    private LibVLC mLibVLC;
	    private ThreadFileDownloadHolder holder; 
	    private long downloadtime;
	    private int downloadedSize = 0;
		private int fileSize = 0;
		private String fileurl="";
	
		private String serverip="http://192.168.1.127:81";
	   public ThreadFileDownloadAdapter() {
	 
					
	        mInflater = LayoutInflater.from(VLCApplication.getAppContext());
	      
	        try {
	            mLibVLC = LibVLC.getInstance();
	        } catch (LibVlcException e) {
	            Log.d(TAG, "LibVlcException encountered in ThreadFileDownloadAdapter", e);
	            return;
	        }

	        EventHandler em = mLibVLC.getPrimaryMediaList().getEventHandler();
	        em.addHandler(new ThreadFileDownloadEventHandler(this));
	       
	    }
	 /*   downloadbutton.setOnClickListener(new OnClickListener() {
			public void onClick(View v) {
				download();
				downloadtime = SystemClock.currentThreadTimeMillis();
			}
		});
*/
	    @Override
	    public int getCount() {
	    	//String s = String.valueOf( mLibVLC.getPrimaryMediaList().size());
	    	
	    	
	    	//return mLibVLC.getPrimaryMediaList().size();
	    	int filenum=0;
	    	String fileurl=mLibVLC.downloadfilelist;
	    	if (!fileurl.equals("0"))
	    			filenum=1;
	    	Log.d("count", fileurl);
	    	
	    
	        return filenum;
	    }

	    @Override
	    public Object getItem(int arg0) {
	       // return mLibVLC.getPrimaryMediaList().getMRL(arg0);
	    	 return arg0;
	    }

	    @Override
	    public long getItemId(int arg0) {
	        // TODO Auto-generated method stub
	        return 0;
	    }

	    @Override
	    public View getView(int position, View convertView, ViewGroup parent) {
	    	//ˢ�µ�ʱ�򴥷�
	    	 Log.d(TAG, " getView" );
	    	 /*
	        DirectoryAdapter.DirectoryViewHolder holder;
	        View v = convertView;

	        ////// If view not created  û����Ƶ 
	        if (v == null) {
	            v = mInflater.inflate(R.layout.audio_browser_item, parent, false);
	            holder = new DirectoryAdapter.DirectoryViewHolder();
	            holder.layout = v.findViewById(R.id.layout_item);
	            holder.title = (TextView) v.findViewById(R.id.title);
	            holder.text = (TextView) v.findViewById(R.id.artist);
	            holder.icon = (ImageView) v.findViewById(R.id.cover);
	            v.setTag(holder);
	        } else
	            holder = (DirectoryAdapter.DirectoryViewHolder) v.getTag();

	        String holderText = "";
	        Media m = mLibVLC.getPrimaryMediaList().getMedia(position);
	        Log.d(TAG, "Loading media position " + position + " - " + m.getTitle());
	        holder.title.setText(m.getTitle());
	        holderText = m.getSubtitle();

	        holder.text.setText(holderText);
	        Bitmap b = AudioUtil.getCover(VLCApplication.getAppContext(), m, 64);
	        if(b != null)
	            holder.icon.setImageBitmap(b);
	        else
	            holder.icon.setImageResource(R.drawable.icon);
	        */

	    	 
	    //	 ThreadFileDownloadHolder holder;
        
		        View v = convertView;

		        ////// If view not created  û����Ƶ 
		        if (v == null) {
		            v = mInflater.inflate(R.layout.videodown, parent, false);
		            holder = new ThreadFileDownloadHolder();
		            holder.icon = (ImageView) v.findViewById(R.id.cover);
		            holder.downloadinfo= (TextView) v.findViewById(R.id.downloadinfo);
		            holder.groupname= (TextView) v.findViewById(R.id.groupname);
		            holder.videoname= (TextView) v.findViewById(R.id.videoname);
		            holder.downloadbutton=(Button) v.findViewById(R.id.downloadbutton);
		            holder. downloadbutton. setOnClickListener( new lvButtonListener( position ) ) ;
		            holder.downloadProgressBar=(ProgressBar) v.findViewById(R.id.downloadProgressBar);
		            fileurl=serverip+mLibVLC.downloadfilelist;
		           
			    
			    	//fileurl="http://192.168.1.127:81/meihao/1.mp4";
			    	holder.groupname.setText("���õ���ҵ");
			    	holder.videoname.setText("��1��-��ҵ�ҡ��߼��쵼�ɲ�ƪ");
			    
		            
		            holder.downloadbutton.setOnClickListener(new OnClickListener() {
		    			public void onClick(View v) {
		    				 Log.d(TAG, "downloadbutton" );
		    				 Log.d(TAG, fileurl );
		    				download();
		    				downloadtime = SystemClock.currentThreadTimeMillis();
		    			}
		    		});
		            v.setTag(holder);
		        } else
		        {
		        		 holder = (ThreadFileDownloadAdapter.ThreadFileDownloadHolder) v.getTag();
			        
		        }

		    
		     
		      
		        
	        return v;
	    }
	    private void download() {
			// ��ȡSD��Ŀ¼
			String dowloadDir = Environment.getExternalStorageDirectory() + "/VVDown/";
			File file = new File(dowloadDir);
			//��������Ŀ¼
			if (!file.exists()) {
				file.mkdirs();
			}
			
			//��ȡ�����߳��������Ϊ�գ����߳�����
			int downloadTN = 4;
			String fileName = "��1��-��ҵ�ҡ��߼��쵼�ɲ�ƪ.mp4";
			//��ʼ����ǰ�����ذ�ť����Ϊ������
			holder.downloadbutton.setClickable(false);
			//��������Ϊ0
			holder.downloadProgressBar.setProgress(0);
			//�����ļ������߳�
			//new downloadTask("http://f1.xiami.net/3110/70071/06_1770692721_2899518.mp3", Integer
			//		.valueOf(downloadTN), dowloadDir + fileName).start();
			
			new downloadTask(fileurl, Integer
					.valueOf(downloadTN), dowloadDir + fileName).start();
		}
	 
		Handler handler = new Handler() {
			@Override
			public void handleMessage(Message msg) {
				//���յ�������ͼ��Ϣʱ��������������ذٷֱȣ�ͬʱ���½�������Ϣ
				int progress = (Double.valueOf((downloadedSize * 1.0 / fileSize * 100))).intValue();
				if (progress == 100) {
					holder.downloadbutton.setClickable(true);
					holder.downloadinfo.setText("������ɣ��뵽����Ƶ���в鿴");
					mLibVLC.downloadfilelist="0";
					register();//��Ȩ���license
				/*	Dialog mdialog = new AlertDialog.Builder(ThreadFileDownloadAdapter)
				.setTitle("��ʾ��Ϣ")
					.setMessage("������ɣ�����ʱΪ:"+(SystemClock.currentThreadTimeMillis()-downloadtime)+"����")
					.setNegativeButton("ȷ��", new DialogInterface.OnClickListener(){
							@Override
							public void onClick(DialogInterface dialog, int which) {
								dialog.dismiss();
							}
						})
						.create();
					mdialog.show();*/
				} else {
					holder.downloadinfo.setText("��ǰ����:" + progress + "%");
				}
				holder.downloadProgressBar.setProgress(progress);
			}
	 
		};
	 
		
		public class downloadTask extends Thread {
			private int blockSize, downloadSizeMore;
			private int threadNum = 5;
			String urlStr, threadNo, fileName;
	 
			public downloadTask(String urlStr, int threadNum, String fileName) {
				this.urlStr = urlStr;
				this.threadNum = threadNum;
				this.fileName = fileName;
			}
	 
			@Override
			public void run() {
				FileDownloadThread[] fds = new FileDownloadThread[threadNum];
				try {
					URL url = new URL(urlStr);
					URLConnection conn = url.openConnection();
					//��ֹ����-1
					InputStream in = conn.getInputStream();
					//��ȡ�����ļ����ܴ�С
					fileSize = conn.getContentLength();
					Log.i("bb", "======================fileSize:"+fileSize);
					//����ÿ���߳�Ҫ���ص�������
					blockSize = fileSize / threadNum;
					// ���������ٷֱȼ������
					downloadSizeMore = (fileSize % threadNum);
					File file = new File(fileName);
					for (int i = 0; i < threadNum; i++) {
						Log.i("bb", "======================i:"+i);
						//�����̣߳��ֱ������Լ���Ҫ���صĲ���
						FileDownloadThread fdt = new FileDownloadThread(url, file, i * blockSize, (i + 1) * blockSize - 1);
						fdt.setName("Thread" + i);
						fdt.start();
						fds[i] = fdt;
					}
					boolean finished = false;
					while (!finished) {
						// �Ȱ������������㶨
						downloadedSize = downloadSizeMore;
						finished = true;
						for (int i = 0; i < fds.length; i++) {
							downloadedSize += fds[i].getDownloadSize();
							if (!fds[i].isFinished()) {
								finished = false;
							}
						}
						handler.sendEmptyMessage(0);
						//�߳���ͣһ��
						sleep(1000);
					}
				} catch (Exception e) {
					e.printStackTrace();
				}
	 
			}
		}
		  public void register() {//ע������Ȩ��
			  Log.e(TAG, "ע������Ȩ��");
	
				 try { 
				        String DeviceInfo=MainActivity.DeviceInfo;
				          String UserName="Bob";
				          String VideoInfo="111111";//�����ļ����ƣ��ļ���С���ļ�����ʱ������� �ļ����ݵ�hashֵ
				          Log.e(TAG, "�����룺"+DeviceInfo);
				          Log.e(TAG, "�û�����"+UserName);
				          Log.e(TAG, "�����룺"+VideoInfo);
				          WebDataInit(DeviceInfo,UserName,VideoInfo);//�ӷ�������ȡ����   ��ʼ�����������
					        
				          
				        } catch (Exception e) {  
				           // TODO Auto-generated catch block  
				           e.printStackTrace();  
				      }
				 
		    }
		  public  void WebDataInit(final String DeviceInfo,final String UserName,final String VideoInfo)
		    {
			 
	    		
		    new Thread(new Runnable() 
		    {
		    	String sn;
		    	
				public void run(){
			    	Log.d("url response", "Runnable");
			    	// handler.postDelayed(this, 3000);
			    	////////////////////json
			    	try {
			    		
			    		 String URL=serverip+"/SoftWareActive.asp";
			    		
			        	String KEYid1 = "DeviceInfo";
			        	String KEYid2 = "UserName";
			        	String KEYid3 = "VideoInfo";
			        		        	
			        	//HttpGet����
			    		//HttpGet request = new HttpGet(URL+"?"+KEYid+"="+id);
			        	//HttpResponse response = new DefaultHttpClient().execute(request);  
			    		
			    		//HttpPost����  
			            HttpPost httpPost = new HttpPost(URL);  
			            List<NameValuePair> params = new ArrayList<NameValuePair>();  
			            params.add(new BasicNameValuePair(KEYid1,DeviceInfo));  
			            params.add(new BasicNameValuePair(KEYid2,UserName));  
			            params.add(new BasicNameValuePair(KEYid3,VideoInfo));  
			            httpPost.setEntity(new UrlEncodedFormEntity(params, HTTP.UTF_8));  
			            Log.d("url response", "URL");
			        	HttpResponse response = new DefaultHttpClient().execute(httpPost);  
			        	Log.d("url response", "3");
			       	//�õ�Ӧ����ַ�������Ҳ��һ�� JSON ��ʽ���������  
			        	String retSrc = EntityUtils.toString(response.getEntity(),"GB2312");  
			        	// ���� JSON ����  
			        	JSONObject result = new JSONObject(retSrc);  
			    		//����JSON�еĸ����ݣ�ע����������
			        	Log.d("url response", "4");
			    		//int sn = result.getInt("sn");
			    		sn=result.getString("sn");//�����Ȩ����
			    	
			    	
			    		//Log.d("url response", String.valueOf(sn));
			    		Log.d("url response", sn);
			    		String videoid=VideoInfo;
			    		MainActivity.saveSharedPreferences(videoid,sn);
				  //	String videosn=loadSharedPreferences(videoid);
			 // 	Log.d("videosn:", videosn);
			    		
			    		
					    
			    	} catch (Exception e)
			    	{
			    		Log.d("url response", "false");
			    		e.printStackTrace();
			    	}
			    
			    	
			    	
				}
		    }).start();
		 
		    
		    
		    
		    
		    
		    
		    
		    
		    
		    
		    
		    }
		 
	    static class ThreadFileDownloadHolder {
	       
	        public EditText downloadnum;
	        public TextView url;
	        public TextView downloadinfo;
	        public TextView groupname;//���õ���ҵ
	        public TextView videoname;
	        public ImageView icon;
	        public Button downloadbutton;
	        public ProgressBar downloadProgressBar;
	    }

	    /**
	     * The media list changed.
	     *
	     * @param added Set to true if the media list was added to
	     * @param uri The URI added/removed
	     * @param index The index added/removed at
	     */
	    public void updateEvent(Boolean added, String uri, int index) {
	        if(added) {
	            Log.v(TAG, "Added index " + index + ": " + uri);
	        } else {
	            Log.v(TAG, "Removed index " + index + ": " + uri);
	        }
	        notifyDataSetChanged();
	    }

	    public void refresh() {
	        this.notifyDataSetChanged();
	    }

	    /**
	     *  Handle changes to the media list
	     */
	    private static class ThreadFileDownloadEventHandler extends WeakHandler<ThreadFileDownloadAdapter> {
	        public ThreadFileDownloadEventHandler(ThreadFileDownloadAdapter owner) {
	            super(owner);
	        }

	        @Override
	        public void handleMessage(Message msg) {
	        	ThreadFileDownloadAdapter adapater = getOwner();
	            if(adapater == null) return;

	            String item_uri = msg.getData().getString("item_uri");
	            int item_index = msg.getData().getInt("item_index");
	            switch (msg.getData().getInt("event")) {
	                case EventHandler.MediaListItemAdded:
	                    adapater.updateEvent(true, item_uri, item_index);
	                    break;
	                case EventHandler.MediaListItemDeleted:
	                    adapater.updateEvent(false, item_uri, item_index);
	                    break;
	            }
	        }
	    };
	    
	    class lvButtonListener implements OnClickListener { 
	        private int position ; 

	        lvButtonListener( int pos) { 
	            position = pos; 
	        } 
	        
	        @Override 
	        public void onClick( View v) { 
	            int vid= v. getId ( ) ; 
	            if ( vid == holder. downloadbutton. getId ( ) ) 
	            {
	            	Log.d(TAG, " buttonClick" );
	            	//download();
					//downloadtime = SystemClock.currentThreadTimeMillis();
	            }
	        } 
	    } 
	}

