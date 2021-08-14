using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using ShellStylesSample;
using ShellStylesSample.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(AppShell), typeof(AppShellPageRenderer))] // comment out for simple shell
namespace ShellStylesSample.Droid
{   
    public class AppShellPageRenderer : ShellRenderer
    {
        public AppShellPageRenderer(Context context) : base(context)
        {

        }
        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            //return base.CreateBottomNavViewAppearanceTracker(shellItem);
            return new BottomTabBar1(Element);
        }
    }

    internal class BottomTabBar1 : IShellBottomNavViewAppearanceTracker
    {
        public BottomTabBar1(Shell element)
        {

        }
        public void Dispose()
        {
            
        }

        public void ResetAppearance(BottomNavigationView bottomView)
        {
            
        }

        public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            bottomView.ItemIconTintList = null;
            int[][] states = new int[][]
             {
                // disabled
                new int[] {-Android.Resource.Attribute.Checked}, // unchecked
                new int[] { Android.Resource.Attribute.Checked }  // pressed
             };
            int[] colors = new int[]
            {
                Color.FromHex("#336699").ToAndroid(),
                Color.FromHex("#336699").ToAndroid()
            };
            ColorStateList colorStateList = new ColorStateList(states, colors);
            bottomView.ItemIconTintList = colorStateList;
            bottomView.ItemTextColor = colorStateList;

            var menu = (BottomNavigationMenuView)bottomView.GetChildAt(0);

            for (int i = 0; i < menu.ChildCount; i++)
            {
                int? tabBarIconHeight = null;
                int? tabBarIconWidth = null;

                // var item = view as BottomNavigationItemView;
                //if (Element != null && Element.CurrentItem != null && Element.CurrentItem.Items.Any())
                //{
                //    var shellSection = Element.CurrentItem.Items.FirstOrDefault(x => x.Title.ToLower() == "addnew");
                //    if (Transforms.GetKeepIconColourIntact(shellSection))
                //    {
                //        var icon = Transforms.GetSelectedIcon(shellSection);
                //        if (string.IsNullOrWhiteSpace(icon))
                //        {
                //            bottomView.Menu.GetItem(i).SetIcon(IdFromTitle(shellSection.Icon, ResourceManager.DrawableClass));
                //        }
                //        else
                //        {
                //            bottomView.Menu.GetItem(i).SetIcon(IdFromTitle(shellSection.Icon, ResourceManager.DrawableClass));
                //        }
                //    }
                //}
                var view = menu.GetChildAt(i);
                if (view == null) return;
                if (view is BottomNavigationItemView)
                {
                    var viewgroup = (ViewGroup)view;
                    for (int j = 0; j < viewgroup.ChildCount; j++)
                    {
                        Android.Views.View v = viewgroup.GetChildAt(j);
                        if (v is ViewGroup)
                        {
                            v.Visibility = ViewStates.Gone;
                        }
                        else
                        {
                            if (v is ImageView icon)
                            {
                                FrameLayout.LayoutParams parames = (FrameLayout.LayoutParams)icon.LayoutParameters;
                                if (tabBarIconHeight != null && tabBarIconWidth != null)
                                {
                                    parames.Height = (int)tabBarIconHeight;
                                    parames.Width = (int)tabBarIconWidth;
                                }
                                parames.Gravity = GravityFlags.Center;
                            }
                        }
                    }
                }
            }
        }
    }
}