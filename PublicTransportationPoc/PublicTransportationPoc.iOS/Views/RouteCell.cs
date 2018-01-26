using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using PublicTransportationPoc.Core.Models;
using UIKit;

namespace PublicTransportationPoc.iOS.Views
{
    public partial class RouteCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("RouteCell");
        public static readonly UINib Nib;

        static RouteCell()
        {
            Nib = UINib.FromName("RouteCell", NSBundle.MainBundle);
        }

        protected RouteCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var bindingSet = this.CreateBindingSet<RouteCell, Route>();

                bindingSet.Bind(NameText).To(m => m.Name);
                bindingSet.Bind(StreatsText).To(m => m.Stations);

                bindingSet.Apply();
            });
        }
    }
}
