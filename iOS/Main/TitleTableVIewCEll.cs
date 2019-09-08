using System;

using Foundation;
using LivongoShowAndTell2.Network;
using UIKit;

namespace LivongoShowAndTell2.iOS.Main
{
    public partial class TitleTableVIewCEll : UITableViewCell, IBindable
    {
        public static readonly NSString Key = new NSString("TitleTableVIewCEll");
        public static readonly UINib Nib;

        static TitleTableVIewCEll()
        {
            Nib = UINib.FromName("TitleTableVIewCEll", NSBundle.MainBundle);
        }

        protected TitleTableVIewCEll(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void Bind(string s)
        {
            this.TitleLabel.Text = s;
        }
    }
}
