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
    [Register ("StationsView")]
    partial class StationsView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RouteText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView StationsTable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (RouteText != null) {
                RouteText.Dispose ();
                RouteText = null;
            }

            if (StationsTable != null) {
                StationsTable.Dispose ();
                StationsTable = null;
            }
        }
    }
}