using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace CheckedRecycleViewApp1
{
    public class PhotoViewHolder: RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }
        public CheckBox MyCheckBox { get; set; }
        public bool IsChecked { get; set; }


        public Button DeleteButton { get; set; }

        public PhotoViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            //Image = itemView.FindViewById<ImageView> (Resource.Id.imageView);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
            MyCheckBox = itemView.FindViewById<CheckBox>(Resource.Id.myCheckBox);

            DeleteButton = itemView.FindViewById<Button>(Resource.Id.deleteBtn);

            // Detect user clicks on the item view and report which item
            // was clicked (by layout position) to the listener:
            itemView.Click += (sender, e) => listener(base.LayoutPosition);

            MyCheckBox.Click += delegate
            {
                if (MyCheckBox.Checked)
                {
                    Console.WriteLine("I can get the adapter position here {0}", AdapterPosition);
                    IsChecked = true;
                }
                else
                {
                    Console.WriteLine("I can get the adapter position here {0}", AdapterPosition);
                    IsChecked = false;
                }
            };

            //DeleteButton.Click += delegate { 
             
            
            //};

        }
    }
}