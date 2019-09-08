using System;

using Foundation;
using LivongoShowAndTell2.Network;
using UIKit;

namespace LivongoShowAndTell2.iOS.Main
{
    public partial class DetailTableViewCell : UITableViewCell, IBindable
    {
        public static readonly NSString Key = new NSString("DetailTableViewCell");
        public static readonly UINib Nib;

        static DetailTableViewCell()
        {
            Nib = UINib.FromName("DetailTableViewCell", NSBundle.MainBundle);
        }

        protected DetailTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void Bind(string s)
        {
            this.DetailLabel.Text = s;
        }
    }
}
