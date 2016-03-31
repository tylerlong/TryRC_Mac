using System;

using AppKit;
using Foundation;

namespace TryRC_Mac
{
	public partial class ViewController : NSViewController
	{
		private RingCentral.Platform platform;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			appKeyTextField.StringValue = NSUserDefaults.StandardUserDefaults.StringForKey ("appKey") ?? "";
			appSecretTextField.StringValue = NSUserDefaults.StandardUserDefaults.StringForKey ("appSecret") ?? "";
			serverPopUpButton.SelectItem (NSUserDefaults.StandardUserDefaults.IntForKey ("server"));
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

		partial void sendSMS (Foundation.NSObject sender)
		{
			// save user input
			NSUserDefaults.StandardUserDefaults.SetString (appKeyTextField.StringValue, "appKey");
			NSUserDefaults.StandardUserDefaults.SetString (appSecretTextField.StringValue, "appSecret");
			NSUserDefaults.StandardUserDefaults.SetInt (serverPopUpButton.IndexOfSelectedItem, "server");
			NSUserDefaults.StandardUserDefaults.SetString (usernameTextField.StringValue, "username");
			NSUserDefaults.StandardUserDefaults.SetString (passwordTextField.StringValue, "password");
			NSUserDefaults.StandardUserDefaults.SetString (sendToTextField.StringValue, "sendTo");
			NSUserDefaults.StandardUserDefaults.SetString (messageTextField.StringValue, "message");

			// send sms
			if (platform == null) {
				platform = new RingCentral.SDK (appKeyTextField.StringValue, appSecretTextField.StringValue,
					serverPopUpButton.IndexOfSelectedItem == 0 ? "https://platform.devtest.ringcentral.com" : "https://platform.ringcentral.com"
				).GetPlatform ();
			}
			if (!platform.LoggedIn ()) {
				var tokens = usernameTextField.StringValue.Split ('-');
				var username = tokens [0];
				var extension = tokens.Length > 1 ? tokens [1] : null;
				platform.Authorize (username, extension, passwordTextField.StringValue, true);
			}
			var request = new RingCentral.Http.Request ("/account/~/extension/~/sms",
				              string.Format ("{{ \"text\": \"{0}\", \"from\": {{ \"phoneNumber\": \"{1}\" }}, \"to\": [{{ \"phoneNumber\": \"{2}\" }}]}}",
					              messageTextField.StringValue, usernameTextField.StringValue, sendToTextField.StringValue));
			var response = platform.Post (request);
			var alert = new NSAlert ();
			alert.MessageText = "Sms sent, status code is: " + response.GetStatus ();
			alert.RunModal ();
		}
	}
}
