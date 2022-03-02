using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using System;
using System.Text.RegularExpressions;

namespace loginApp.Resources.drawable.activities
{
    [Activity(Label = "loginActivity", Theme = "@style/AppTheme.NoActionBar", WindowSoftInputMode = SoftInput.AdjustPan)]

    public class Register_Activity : Activity
    {
        EditText enterNameEditText;
        EditText enterUserNameEditText;
        EditText enterPasswordEditText;
        EditText enterEmailEditText;
        TextView alreadyHaveTextView;
        Button registerButton;
        ImageButton facbookIcon;
        ImageButton googleIcon;
        Intent intent;
        Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex UserRegex = new Regex("^[a-z-A-Z- ]*$");////("^[a-zA-Z]*$");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register_main);
            uireference();
            enterNameEditText.TextChanged += EnterNameEditText_TextChanged;
            alreadyHaveTextView.Click += AlreadyHaveTextView_Click;
            registerButton.Click += RegisterButton_Click;
            facbookIcon.Click += FacbookIcon_Click;
            googleIcon.Click += GoogleIcon_Click;
        }

        private void EnterNameEditText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UserRegex.IsMatch(enterNameEditText.Text))
            {
                return;
            }
            else
            {
                enterNameEditText.Error = "Alphabets only!";
            }
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!isValidNAme() && !isValidEmail(enterEmailEditText.Text) && !isValidUserName() && !isValidPassword())
            {
                return;
            }
            if (isValidNAme() && isValidEmail(enterEmailEditText.Text) && isValidUserName() && isValidPassword())
            {
                intent = new Intent(this, typeof(Login_Activity));
                StartActivity(intent);
                FinishAffinity();
            }
            else
                Toast.MakeText(this, "This ain't workin", ToastLength.Short).Show();
        }
        bool isValidNAme()
        {
            if (enterNameEditText.Text == "")
            {
                enterNameEditText.Error = "Give correct input and no numbers allowed";
                return false;
            }
            return true;
        }
        bool isValidUserName()
        {
            if (enterUserNameEditText.Text == "")
            {
                enterUserNameEditText.Error = "Can't be empty";
                return false;
            }
            return true;
        }

        public bool isValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))

            {
                enterEmailEditText.Error = "Enter correct email!";
                return false;
            }

            else if (EmailRegex.IsMatch(email))
            {
                return true;
            }
            else
            {
                enterEmailEditText.Error = "Enter correct email!";
                return false;
            }
        }

        bool isValidPassword()
        {
            if (enterPasswordEditText.Text.Length < 8)
            {
                enterPasswordEditText.Error = "must be greater than 8 cahracters";
                return false;
            }
            return true;
        }
        private void GoogleIcon_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "www.google.com/", ToastLength.Short).Show();

        }
        private void FacbookIcon_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "www.facebook.com/", ToastLength.Short).Show();
        }
        private void AlreadyHaveTextView_Click(object sender, EventArgs e)
        {
            intent = new Intent(this, typeof(Login_Activity));
            StartActivity(intent);
            FinishAffinity();
        }
        public void uireference()
        {
            alreadyHaveTextView = (TextView)FindViewById(Resource.Id.loginYourAccountTextView);
            enterNameEditText = (EditText)FindViewById(Resource.Id.nameOfUserEditText);
            enterUserNameEditText = (EditText)FindViewById(Resource.Id.userNameEditText);
            enterEmailEditText = (EditText)FindViewById(Resource.Id.emailEditText);
            registerButton = (Button)FindViewById(Resource.Id.registerButton);
            facbookIcon = (ImageButton)FindViewById(Resource.Id.facebookIconImageButton);
            googleIcon = (ImageButton)FindViewById(Resource.Id.googleIconImageButton);
            enterPasswordEditText = (EditText)FindViewById(Resource.Id.passwordEditText);
        }
    }
}
