using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HelloMonoTouch
{
	public partial class HelloMonoTouchViewController : UIViewController
	{
		protected int _numberOfTimesClicked = 0;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public HelloMonoTouchViewController ()
			: base (UserInterfaceIdiomIsPhone ? "HelloMonoTouchViewController_iPhone" : "HelloMonoTouchViewController_iPad", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			btnClickMe.TouchUpInside += (sender, e) => {
				_numberOfTimesClicked++;
				lblOutput.Text = "Clicked [" + _numberOfTimesClicked.ToString() + "] times!";
			};
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			if (UserInterfaceIdiomIsPhone) {
				return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
			} else {
				return true;
			}
		}

		partial void actnButtonClick (NSObject sender)
		{
			lblOutput.Text = "Action button " + ((UIButton)sender).CurrentTitle + " clicked.";
		}
	}
}

