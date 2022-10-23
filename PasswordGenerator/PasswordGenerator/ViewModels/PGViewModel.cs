using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace PasswordGenerator.ViewModels
{
	class PGViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		private bool? useCapitalLetters = true;
		public bool? UseCapitalLetters
		{
			get => useCapitalLetters;
			set
			{
				useCapitalLetters = value;
				OnPropertyChanged();
			}
		}

		private bool? useLowerLetters = true;
		public bool? UseLowerLetters
		{
			get => useLowerLetters;
			set
			{
				useLowerLetters = value;
				OnPropertyChanged();
			}
		}

		private bool? useNumbers = true;
		public bool? UseNumbers
		{
			get => useNumbers;
			set
			{
				useNumbers = value;
				OnPropertyChanged();
			}
		}
		private bool? useSpecialChars = true;
		public bool? UseSpecialChars
		{
			get => useSpecialChars;
			set
			{
				useSpecialChars = value;
				OnPropertyChanged();
			}
		}

		private bool? useMyChars = false;
		public bool? UseMyChars
		{
			get => useMyChars;
			set
			{
				useMyChars = value;
				OnPropertyChanged();
			}
		}
		private string myChars = "";
		public string MyChars
		{
			get => myChars;
			set
			{
				myChars = value;
				OnPropertyChanged();
			}
		}
		public bool? IsSelectedUse
		{
			get => UseCapitalLetters == true || UseLowerLetters == true || (UseMyChars == true && MyChars != "") || UseNumbers == true || UseSpecialChars == true ;
		}
		private string password;
		public string Password
		{
			get => password;
			set
			{
				password = value;
				OnPropertyChanged();
			}
		}

		private int length = 20;
		public int Length
		{
			get => length;
			set
			{
				length = value;
				OnPropertyChanged();
			}
		}

		public ICommand GeneratePassword
		{
			get => new DelegateCommand((obj) => Password = IsSelectedUse == true ? 
				RandomText.GenRandText(useCapitalLetters == true, useLowerLetters == true, useNumbers == true, useSpecialChars == true, length, useMyChars == true ? myChars :"") : 
				"");
			
		}
		public ICommand CopyPassword
		{
			get => new DelegateCommand((obj) => Clipboard.SetText(Password));
		}
	}
}
