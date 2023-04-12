using Plugin.NFC;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BadgeApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			if (CrossNFC.Current.IsAvailable)
			{
				if (!CrossNFC.Current.IsEnabled)
				{
					Debug.WriteLine("MainPage", "NFC Não ativada.");
					return;
				}

				// Event raised when a ndef message is received.
				CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;
				// Event raised when a ndef message has been published.
				CrossNFC.Current.OnMessagePublished += Current_OnMessagePublished;
				// Event raised when a tag is discovered. Used for publishing.
				CrossNFC.Current.OnTagDiscovered += Current_OnTagDiscovered;
				// Event raised when NFC listener status changed
				CrossNFC.Current.OnTagListeningStatusChanged += Current_OnTagListeningStatusChanged;

				// Android Only:
				// Event raised when NFC state has changed.
				CrossNFC.Current.OnNfcStatusChanged += Current_OnNfcStatusChanged;

				// iOS Only: 
				// Event raised when a user cancelled NFC session.
				//CrossNFC.Current.OniOSReadingSessionCancelled += Current_OniOSReadingSessionCancelled;
			}
			else
			{
				Debug.WriteLine("MainPage", "NFC não suportada");
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			CrossNFC.Current.StartListening();
		}

		private void Current_OnMessageReceived(ITagInfo tagInfo)
		{
			Debug.WriteLine("MainPage", "Mensagem recebida");
		}

		private void Current_OnMessagePublished(ITagInfo tagInfo)
		{
			Debug.WriteLine("MainPage", "Mensagem enviada");
		}

		private void Current_OnTagDiscovered(ITagInfo tagInfo, bool format)
		{
			throw new NotImplementedException();
		}

		private void Current_OnTagListeningStatusChanged(bool isListening)
		{
			//throw new NotImplementedException();
		}

		private void Current_OnNfcStatusChanged(bool isEnabled)
		{
			throw new NotImplementedException();
		}
	}
}
