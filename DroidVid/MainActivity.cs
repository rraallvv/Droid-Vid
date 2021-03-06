﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Threading.Tasks;
using Android.Media;
using Android.Util;

namespace DroidVid
{
    [Activity(Label = "DroidVid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, ISurfaceHolderCallback
    {
        //not sure this is right... but...
        private static string dir = "/mnt/shared/extSdCard/";//"/Removable/MicroSD/";//
        private static String SAMPLE = dir + "Video_2014_5_7__15_33_44.mpg";//"Video_2014_5_8__9_12_35.mpg";//"Video_2014_5_6__15_55_19.mpg";//
        //private static string SAMPLE = "udp://@127.0.0.1:12345";
        //Android.OS.Environment.ExternalStorageDirectory.ToString() + "/video.mp4";
        //FilePlayer mPlayer;
        Player mPlayer;

        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            FilePlayer.dir = dir;
            FilePlayer.SAMPLE = SAMPLE;


            mPlayer = null;

            //create the surface view for drawing to, and wire up callbacks(events)
            var sv = new SurfaceView(this);
            sv.Holder.AddCallback(this);
            sv.KeepScreenOn = true;

            SetContentView(sv);

        }

        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            Log.Info("MainActivity", "Attached--------------------------");



        }

        public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
        {
            //throw new NotImplementedException();
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            Log.Info("MainActivity", "SurfaceCreated--------------------------");

            if (mPlayer == null)
            {

                //mPlayer = new FilePlayer(holder.Surface);//this works
                //mPlayer = new BufferPlayer2(holder.Surface);//this works, but choppy
                mPlayer = new BufferPlayer(holder.Surface);//this works great

                mPlayer.RunAsync();
            }
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            //throw new NotImplementedException();

        }

    }
}