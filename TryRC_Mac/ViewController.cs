using System;

using AppKit;
using Foundation;

namespace TryRC_Mac
{
	public partial class ViewController : NSViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			appKeyTextField.StringValue = NSUserDefaults.StandardUserDefaults.StringForKey ("appKey") ?? "";
			appSecretTextField.StringValue = NSUserDefaults.StandardUserDefaults.StringForKey ("appSecret") ?? "";
			serverPopUpButton.SelectItem(NSUserDefaults.StandardUserDefaults.IntForKey ("server"));
			usernameTextField.StringValue = NSUserDefaults.StandardUserDefaults.StringForKey ("username") ?? "";
			passwordTextField.StringValue = NSUserDefaults.StandardUserDefaults.StringForKey ("password") ?? "";
			sendToTextField.StringValue = NSUserDefaults.StandardUserDefaults.StringForKey ("sendTo") ?? "";
			messageTextField.StringValue = NSUserDefaults.StandardUserDefaults.StringForKey ("message") ?? "";
		}

		public override NSObject RepresentedObject {
			get {
				return base.RepresentedObject;
			}
			set {
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}

		partial void sendSMS(Foundation.NSObject sender)
		{
			NSUserDefaults.StandardUserDefaults.SetString(appKeyTextField.StringValue, "appKey");
			NSUserDefaults.StandardUserDefaults.SetString(appSecretTextField.StringValue, "appSecret");
			NSUserDefaults.StandardUserDefaults.SetInt(serverPopUpButton.IndexOfSelectedItem, "server");
			NSUserDefaults.StandardUserDefaults.SetString(usernameTextField.StringValue, "username");
			NSUserDefaults.StandardUserDefaults.SetString(passwordTextField.StringValue, "password");
			NSUserDefaults.StandardUserDefaults.SetString(sendToTextField.StringValue, "sendTo");
			NSUserDefaults.StandardUserDefaults.SetString(messageTextField.StringValue, "message");
		}
	}
}
