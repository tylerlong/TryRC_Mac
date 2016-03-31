// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TryRC_Mac
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField appKeyTextField { get; set; }

		[Outlet]
		AppKit.NSSecureTextField appSecretTextField { get; set; }

		[Outlet]
		AppKit.NSTextField messageTextField { get; set; }

		[Outlet]
		AppKit.NSSecureTextField passwordTextField { get; set; }

		[Outlet]
		AppKit.NSTextField sendToTextField { get; set; }

		[Outlet]
		AppKit.NSPopUpButton serverPopUpButton { get; set; }

		[Outlet]
		AppKit.NSTextField usernameTextField { get; set; }

		[Action ("sendSMS:")]
		partial void sendSMS (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (appKeyTextField != null) {
				appKeyTextField.Dispose ();
				appKeyTextField = null;
			}

			if (appSecretTextField != null) {
				appSecretTextField.Dispose ();
				appSecretTextField = null;
			}

			if (messageTextField != null) {
				messageTextField.Dispose ();
				messageTextField = null;
			}

			if (passwordTextField != null) {
				passwordTextField.Dispose ();
				passwordTextField = null;
			}

			if (sendToTextField != null) {
				sendToTextField.Dispose ();
				sendToTextField = null;
			}

			if (serverPopUpButton != null) {
				serverPopUpButton.Dispose ();
				serverPopUpButton = null;
			}

			if (usernameTextField != null) {
				usernameTextField.Dispose ();
				usernameTextField = null;
			}
		}
	}
}
