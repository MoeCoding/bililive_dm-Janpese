﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bililive_dm
{
    /// <summary>
    /// DanmakuTextControl.xaml 的互動邏輯
    /// </summary>
    public partial class DanmakuTextControl : UserControl
    {
        public DanmakuTextControl()
        {
            this.InitializeComponent();
            this.Loaded += DanmakuTextControl_Loaded;
            this.Text.FontFamily = new FontFamily(DefaultStore.MainFontFamily);

            var sb = (Storyboard) this.Resources["Storyboard1"];
            Storyboard.SetTarget(sb.Children[2], this);

            (sb.Children[0] as DoubleAnimationUsingKeyFrames).KeyFrames[1].KeyTime =
                KeyTime.FromTimeSpan(new TimeSpan(Convert.ToInt64(Store.MainOverlayEffect1*TimeSpan.TicksPerSecond)));

            (sb.Children[1] as DoubleAnimationUsingKeyFrames).KeyFrames[1].KeyTime =
                KeyTime.FromTimeSpan(new TimeSpan(Convert.ToInt64(Store.MainOverlayEffect1*TimeSpan.TicksPerSecond)));

            (sb.Children[1] as DoubleAnimationUsingKeyFrames).KeyFrames[2].KeyTime =
                KeyTime.FromTimeSpan(
                    new TimeSpan(
                        Convert.ToInt64((Store.MainOverlayEffect2 + Store.MainOverlayEffect1)*TimeSpan.TicksPerSecond)));

            (sb.Children[2] as DoubleAnimationUsingKeyFrames).KeyFrames[0].KeyTime =
                KeyTime.FromTimeSpan(
                    new TimeSpan(
                        Convert.ToInt64((Store.MainOverlayEffect3 + Store.MainOverlayEffect2 + Store.MainOverlayEffect1)*
                                        TimeSpan.TicksPerSecond)));
            (sb.Children[2] as DoubleAnimationUsingKeyFrames).KeyFrames[1].KeyTime =
                KeyTime.FromTimeSpan(
                    new TimeSpan(
                        Convert.ToInt64((Store.MainOverlayEffect4 + Store.MainOverlayEffect3 + Store.MainOverlayEffect2 +
                                         Store.MainOverlayEffect1)*TimeSpan.TicksPerSecond)));
        }


        public void ChangeHeight()
        {
            this.TextBox.FontSize = Store.MainOverlayFontsize;
            this.TextBox.Measure(new Size(Store.MainOverlayWidth, int.MaxValue));
            var sb = (Storyboard) this.Resources["Storyboard1"];
            var kf1 = sb.Children[0] as DoubleAnimationUsingKeyFrames;
            kf1.KeyFrames[1].Value = this.TextBox.DesiredSize.Height;
        }

   

        private void DanmakuTextControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= DanmakuTextControl_Loaded;
        }
    }
}