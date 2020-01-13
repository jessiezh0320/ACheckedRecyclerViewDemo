using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace CheckedRecycleViewApp1
{
    public class PhotoAlbumAdapter: RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        //public Photo[] mPhotoAlbum;
        public static List<Photo> mPhotoAlbum = new List<Photo>();

        public static RecyclerView.Adapter adapter;

        //AppCompatActivity activity;
        //private List<Photo> branchesList;

        public PhotoAlbumAdapter(List<Photo> branchesList)
        {
            //mPhotoAlbum = branchesList.ToArray();
            adapter = this;
            mPhotoAlbum = branchesList;
        }

        //public void UpDateData(Photo[] temp) {
        //    mPhotoAlbum = temp;
        //    NotifyDataSetChanged();
        //}

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoCardView, parent, false);

            PhotoViewHolder vh = new PhotoViewHolder(itemView, OnClick);
           
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder vh = holder as PhotoViewHolder;
            //***********************
            Photo item=   mPhotoAlbum[position];

            vh.Caption.Text = item.Caption;

            vh.MyCheckBox.SetOnCheckedChangeListener(null);
            vh.MyCheckBox.SetOnCheckedChangeListener(new MyListener(item));
            vh.MyCheckBox.Checked = item.isChecked;

            vh.DeleteButton.SetOnClickListener(new MyRemoveItem(item,position));

        }


        class MyRemoveItem : Java.Lang.Object, View.IOnClickListener
        {
            Photo photo;
            int position;
            public MyRemoveItem(Photo item,int position) {
                this.photo = item;
                this.position = position;
            }

            public void OnClick(View v)
            {
                //mPhotoAlbum

                mPhotoAlbum.Remove(photo);

                adapter.NotifyDataSetChanged();
            }
        }



        class MyListener : Java.Lang.Object, CompoundButton.IOnCheckedChangeListener
        {
            Photo photo;

            public MyListener( Photo item)
            {
                this.photo = item;
            }

            public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
            {
                photo.isChecked = isChecked;
            }
        }

        public override int ItemCount
        {
            //get { return mPhotoAlbum.Length; }
            get { return mPhotoAlbum.Count; }
        }

        // Raise an event when the item-click takes place:
        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }
}