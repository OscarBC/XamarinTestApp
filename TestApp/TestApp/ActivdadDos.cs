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
using Android.Support.V4.View;
using Android.Support.V4.App;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;


namespace TestApp
{
	[Activity (Label = "ActivdadDos")]			
	public class ActivdadDos : FragmentActivity
	{

		public FragmentAdapter mAdapter;
		public ViewPager mPager;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.LayoutActividadDos);

			TextView user = FindViewById<TextView> (Resource.Id.user);
			user.Text = Intent.GetStringExtra("user") ?? "No user info";

			mAdapter = new FragmentAdapter (SupportFragmentManager);
			mPager = FindViewById<ViewPager> (Resource.Id.pager);
			mPager.Adapter = mAdapter;

		}
	}


	public class FragmentAdapter : FragmentPagerAdapter
	{
		int mCount;

		public FragmentAdapter (FragmentManager fm) : base (fm)
		{
			mCount = 3;
		}

		public override Fragment GetItem (int position)
		{
			return new Fragmento ();
		}

		public override int Count {
			get {
				return mCount;	
			}	
		}

		public void SetCount (int count)
		{
			Console.WriteLine ("Setting count to " + count);
			if (count > 0 && count <= 10) {
				mCount = count;
				NotifyDataSetChanged ();
			}
		}
	}


}

