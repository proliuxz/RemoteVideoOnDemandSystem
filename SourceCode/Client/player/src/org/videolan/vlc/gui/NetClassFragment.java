/*****************************************************************************
 * HistoryFragment.java
 *****************************************************************************
 * Copyright © 2012-2013 VLC authors and VideoLAN
 * Copyright © 2012-2013 Edward Wang
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

import org.videolan.vlc.R;

import android.os.Bundle;
import android.util.Log;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.LayoutInflater;
import android.view.MenuInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.actionbarsherlock.app.SherlockListFragment;

public class NetClassFragment extends SherlockListFragment {
    public final static String TAG = "VLC/NetClassFragment";

    private NetClassAdapter mNetClassAdapter;

    /* All subclasses of Fragment must include a public empty constructor. */
    public NetClassFragment() { }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        mNetClassAdapter = new NetClassAdapter();
        Log.d(TAG, "NetClassFragment()");
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        View v = inflater.inflate(R.layout.netclass_list, container, false);
        setListAdapter(mNetClassAdapter);
        final ListView listView = (ListView)v.findViewById(android.R.id.list);
        registerForContextMenu(listView);
        return v;
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo) {
        MenuInflater menuInflater = getActivity().getMenuInflater();
        menuInflater.inflate(R.menu.history_view, menu);
    }
   

    public void refresh() {
        Log.d(TAG, "Refreshing view!");
        if( mNetClassAdapter != null )
            mNetClassAdapter.refresh();
    }
    
}
