// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace PublicTransportationPoc.iOS.Views
{
    [Register ("RouteCell")]
    partial class RouteCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NameText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel StreatsText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (NameText != null) {
                NameText.Dispose ();
                NameText = null;
            }

            if (StreatsText != null) {
                StreatsText.Dispose ();
                StreatsText = null;
            }
        }
    }
}