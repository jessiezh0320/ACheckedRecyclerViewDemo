using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CheckedRecycleViewApp1
{
    public class Photo
    {
        public int mPhotoID;
        public string mCaption;

        public bool isChecked {  get; set; }

        //public bool IsChecked {

        //    get { return isChecked; }
        //}



        public int mBranchName;

        public int PhotoID
        {
            get { return mPhotoID; }
        }

        public string Caption
        {
            get { return mCaption; }
        }

        public int BranchName
        {
            get { return mBranchName; }
        }
    }
}