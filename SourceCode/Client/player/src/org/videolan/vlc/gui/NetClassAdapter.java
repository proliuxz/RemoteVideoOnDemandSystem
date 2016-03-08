/*****************************************************************************
 * HistoryAdapter.java
 *****************************************************************************
 * Copyright 漏 2012-2013 VLC authors and VideoLAN
 * Copyright 漏 2012-2013 Edward Wang
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston MA 02110-1301, USA.
 *****************************************************************************/
package org.videolan.vlc.gui;

import org.videolan.libvlc.EventHandler;
import org.videolan.libvlc.LibVLC;
import org.videolan.libvlc.LibVlcException;
import org.videolan.vlc.R;
import org.videolan.vlc.VLCApplication;

import android.graphics.Bitmap;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

public class NetClassAdapter extends BaseAdapter {
    public final static String TAG = "VLC/NetClassAdapter";
    public final static int vidnum = 0;
    public final static String title[]={"第1集","第2集","第3集","第4集","第5集","第6集","第7集","第8集","第9集","第10集","第11集","第12集","第13集","第14集","第15集","第16集","第17集","第18集","第19集","第20集"};
    public final static int count[]={1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
    public final static int image[]={R.drawable.ic_play_glow,R.drawable.ic_play_normal,};
    private LayoutInflater mInflater;
    private LibVLC mLibVLC;
    public static String videourl=null;
    public static int videonum=0;

    public NetClassAdapter() {
        mInflater = LayoutInflater.from(VLCApplication.getAppContext());
        try {
            mLibVLC = LibVLC.getInstance();
        } catch (LibVlcException e) {
            Log.d(TAG, "LibVlcException encountered in NetClassAdapter", e);
            return;
        }

        EventHandler em = mLibVLC.getPrimaryMediaList().getEventHandler();
        //em.addHandler(new NetClassEventHandler(this));
    }

    @Override
    public int getCount() {
        return NetClass2Fragment.vidnum; //mLibVLC.getPrimaryMediaList().size();
    }

    @Override
    public Object getItem(int arg0) {
        return mLibVLC.getPrimaryMediaList().getMRL(arg0);
    }

    @Override
    public long getItemId(int arg0) {
        // TODO Auto-generated method stub
        return 0;
    }
    
    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        DirectoryAdapter.DirectoryViewHolder2 holder;
        View v = convertView; 
        // If view not created
        /*if (v == null) {*/
            v = mInflater.inflate(R.layout.netclass, parent, false);
            holder = new DirectoryAdapter.DirectoryViewHolder2();
            holder.layout = v.findViewById(R.id.netclass);
            holder.title = (TextView) v.findViewById(R.id.TV);
            holder.title.setText(title[position]);
           // holder.text = (TextView) v.findViewById(R.id.artist);
            holder.icon = (ImageView) v.findViewById(R.id.cover);
            holder.icon.setImageResource(image[position%2]);
            holder.button = (Button) v.findViewById(R.id.netclassbutton);
            holder.button.setTag(position+1);
        /*
        }
        else*/
        //holder = (DirectoryAdapter.DirectoryViewHolder) v.getTag();

        //String holderText = "";
        //Media m = mLibVLC.getPrimaryMediaList().getMedia(position);
        //Log.d(TAG, "Loading media position " + position + " - " + m.getTitle());
        //holder.title.setText(m.getTitle());
        //holderText = "这是第"+position+"集";

        //holder.text.setText(holderText);
        //Bitmap b = AudioUtil.getCover(VLCApplication.getAppContext(), m, 64);
        //if(b != null)
        //   holder.icon.setImageBitmap(b);
        //else
        //holder.icon.setImageResource(R.drawable.icon);
            
        	holder.button.setOnClickListener(new OnClickListener()
        	{
        		 @Override    
                 public void onClick(View v) {
        			 int tag =(Integer) v.getTag();
        			 videourl=MainActivity.vurl+tag+".mp4";
        			 videonum=tag;
        			 MainActivity.playclassvideo(MainActivity.vurl+tag+".mp4");
        			 //MainActivity.playclassvideo("http://192.168.1.120:81/vview/j001/1.mp4");
                 }    
        		
        	});
        return v;
    }

	/**
     * The media list changed.
     *
     * @param added Set to true if the media list was added to
     * @param uri The URI added/removed
     * @param index The index added/removed at
     */
    /*public void updateEvent(Boolean added, String uri, int index) {
        if(added) {
            Log.v(TAG, "Added index " + index + ": " + uri);
        } else {
            Log.v(TAG, "Removed index " + index + ": " + uri);
        }
        notifyDataSetChanged();
    }*/

    public void refresh() {
        this.notifyDataSetChanged();
    }

    /**
     *  Handle changes to the media list
     */
   /* private static class NetClassEventHandler extends WeakHandler<NetClassAdapter> {
        public NetClassEventHandler(NetClassAdapter owner) {
            super(owner);
        }

        @Override
        public void handleMessage(Message msg) {
            NetClassAdapter adapater = getOwner();
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
    };*/
    
}
