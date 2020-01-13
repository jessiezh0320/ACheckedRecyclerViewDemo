using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Support.V7.Widget;

namespace CheckedRecycleViewApp1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
       public static  Photo[] mBuiltInPhotos;

        List<Photo> loadBranch = new List<Photo>();

        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        PhotoAlbumAdapter mAdapter;

        //SearchView searchViewBranch;
        EditText searchViewBranch;
        Button BtnProceed;

        Button resultBtn;

      public static  List<string> SelectedBranchCode = new List<string>();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            initData();

            mAdapter = new PhotoAlbumAdapter(loadBranch);
            mAdapter.ItemClick += OnItemClick;
            mRecyclerView.SetAdapter(mAdapter);

            



            searchViewBranch = FindViewById<EditText>(Resource.Id.searchView1);

            BtnProceed = FindViewById<Button>(Resource.Id.searchBtn);
            BtnProceed.Click += delegate {
                string word = searchViewBranch.Text.Trim().ToString();
                FindInsideList(word);
            };


            resultBtn = FindViewById<Button>(Resource.Id.resultBtn);

            resultBtn.Click += delegate {
                List<Photo> checkedList = new List<Photo>();

                for (int i=0;i< loadBranch.Count;i++) {
                    Photo temp = loadBranch[i];
                    System.Diagnostics.Debug.WriteLine("123**item-" + i + " : Caption= " + temp.Caption+" ischecked = " + temp.isChecked);

                    if (temp.isChecked) {
                        checkedList.Add(temp);
                    }
                }

                foreach(Photo item in checkedList) {
                    System.Diagnostics.Debug.WriteLine("123**checked item-"  + " : Caption= " + item.Caption + " ischecked = " + item.isChecked);
                }


            };
        }

        //private List<Photo> FindInsideList(string text)
        private void FindInsideList(string text)
        {/*
            if (text != null && text.Length > 0)
            {
                List<Photo> filteredList = new List<Photo>();
                foreach (var itm in loadBranch)
                {
                    if (itm != null)
                    {
                        text = text.ToLower();

                        if (itm.mCaption != null ? itm.mCaption.ToLower().Contains(text) : false)
                        {
                            filteredList.Add(itm);
                        }
                    }
                }
                mAdapter.UpDateData(filteredList.ToArray());
            }
            else
            {
                mAdapter.UpDateData(loadBranch.ToArray());
            }*/
        }


        private void initData() {

             mBuiltInPhotos =  new Photo[] {
            new Photo { mPhotoID = Resource.Drawable.buckingham_guards,
                        mCaption = "Buckingham Palace",isChecked=false },
            new Photo { mPhotoID = Resource.Drawable.la_tour_eiffel,
                        mCaption = "The Eiffel Tower" ,isChecked=false},
            new Photo { mPhotoID = Resource.Drawable.louvre_1,
                        mCaption = "The Louvre",isChecked=false },
            new Photo { mPhotoID = Resource.Drawable.before_mobile_phones,
                        mCaption = "Before mobile phones",isChecked=false },
            new Photo { mPhotoID = Resource.Drawable.big_ben_1,
                        mCaption = "Big Ben skyline" ,isChecked=false},
            new Photo { mPhotoID = Resource.Drawable.big_ben_2,
                        mCaption = "Big Ben from below" ,isChecked=false},
            new Photo { mPhotoID = Resource.Drawable.london_eye,
                        mCaption = "The London Eye",isChecked=false },
            new Photo { mPhotoID = Resource.Drawable.eurostar,
                        mCaption = "Eurostar Train",isChecked=false },
            //new Photo { mPhotoID = Resource.Drawable.arc_de_triomphe,
            //            mCaption = "Arc de Triomphe" },
            //new Photo { mPhotoID = Resource.Drawable.louvre_2,
            //            mCaption = "Inside the Louvre" },
            //new Photo { mPhotoID = Resource.Drawable.versailles_fountains,
            //            mCaption = "Versailles fountains" },
            //new Photo { mPhotoID = Resource.Drawable.modest_accomodations,
            //            mCaption = "Modest accomodations" },
            //new Photo { mPhotoID = Resource.Drawable.notre_dame,
            //            mCaption = "Notre Dame" },
            //new Photo { mPhotoID = Resource.Drawable.inside_notre_dame,
            //            mCaption = "Inside Notre Dame" },
            //new Photo { mPhotoID = Resource.Drawable.seine_river,
            //            mCaption = "The Seine" },
            //new Photo { mPhotoID = Resource.Drawable.rue_cler,
            //            mCaption = "Rue Cler" },
            //new Photo { mPhotoID = Resource.Drawable.champ_elysees,
            //            mCaption = "The Avenue des Champs-Elysees" },
            //new Photo { mPhotoID = Resource.Drawable.seine_barge,
            //            mCaption = "Seine barge" },
            //new Photo { mPhotoID = Resource.Drawable.versailles_gates,
            //            mCaption = "Gates of Versailles" },
            //new Photo { mPhotoID = Resource.Drawable.edinburgh_castle_2,
            //            mCaption = "Edinburgh Castle" },
            //new Photo { mPhotoID = Resource.Drawable.edinburgh_castle_1,
            //            mCaption = "Edinburgh Castle up close" },
            //new Photo { mPhotoID = Resource.Drawable.old_meets_new,
            //            mCaption = "Old meets new" },
            //new Photo { mPhotoID = Resource.Drawable.edinburgh_from_on_high,
            //            mCaption = "Edinburgh from on high" },
            //new Photo { mPhotoID = Resource.Drawable.edinburgh_station,
            //            mCaption = "Edinburgh station" },
            //new Photo { mPhotoID = Resource.Drawable.scott_monument,
            //            mCaption = "Scott Monument" },
            //new Photo { mPhotoID = Resource.Drawable.view_from_holyrood_park,
            //            mCaption = "View from Holyrood Park" },
            //new Photo { mPhotoID = Resource.Drawable.tower_of_london,
            //            mCaption = "Outside the Tower of London" },
            //new Photo { mPhotoID = Resource.Drawable.tower_visitors,
            //            mCaption = "Tower of London visitors" },
            //new Photo { mPhotoID = Resource.Drawable.one_o_clock_gun,
            //            mCaption = "One O'Clock Gun" },
            //new Photo { mPhotoID = Resource.Drawable.victoria_albert,
            //            mCaption = "Victoria and Albert Museum" },
            //new Photo { mPhotoID = Resource.Drawable.royal_mile,
            //            mCaption = "The Royal Mile" },
            //new Photo { mPhotoID = Resource.Drawable.museum_and_castle,
            //            mCaption = "Edinburgh Museum and Castle" },
            //new Photo { mPhotoID = Resource.Drawable.portcullis_gate,
            //            mCaption = "Portcullis Gate" },
            //new Photo { mPhotoID = Resource.Drawable.to_notre_dame,
            //            mCaption = "Left or right?" },
            //new Photo { mPhotoID = Resource.Drawable.pompidou_centre,
            //            mCaption = "Pompidou Centre" },
            //new Photo { mPhotoID = Resource.Drawable.heres_lookin_at_ya,
            //            mCaption = "Here's Lookin' at Ya!" },
            };

            loadBranch = new List<Photo>(mBuiltInPhotos);


        }

        void OnItemClick(object sender, int position)
        {
            int photoNum = position + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }
    }
}