// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace LivongoShowAndTell2.iOS.Main
{
	[Register ("DetailTableViewCell")]
	partial class DetailTableViewCell
	{
		[Outlet]
		UIKit.UILabel DetailLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DetailLabel != null) {
				DetailLabel.Dispose ();
				DetailLabel = null;
			}
		}
	}
}
