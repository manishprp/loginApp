using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using loginApp.Resources.drawable.activities;


namespace loginApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false, WindowSoftInputMode = Android.Views.SoftInput.AdjustPan)]
    public class Login_Activity : AppCompatActivity
    {
        TextView loginTextView;
        Button loginButton;
        ImageButton facbookIcon;
        ImageButton googleIcon;
        EditText usernameEditText;
        EditText passwordEditText;
        TextView forgotPasswordTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_main);
            uireferences();
            clickevents();
        }
        public void clickevents()
        {
            loginButton.Click += LoginButton_Click;
            loginTextView.Click += LoginTextView_Click;
            facbookIcon.Click += FacbookIcon_Click;
            googleIcon.Click += GoogleIcon_Click;
            forgotPasswordTextView.Click += forgotPasswordTextView_Click;
        }
        private void LoginTextView_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Register_Activity));
            StartActivity(intent);
            FinishAffinity();
        }
        private void forgotPasswordTextView_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "Thikh se yaad karo", ToastLength.Short).Show();
        }

        private void GoogleIcon_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "www.google.com/", ToastLength.Short).Show();

        }
        private void FacbookIcon_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "www.facebook.com/", ToastLength.Short).Show();
        }
        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            if (!isValidUserName() && !isValidPassword())

                return;

            if (isValidUserName() && isValidPassword())
            {
                usernameEditText.Text = "";
                passwordEditText.Text = "";
                Toast.MakeText(this, "Logged in successfully", ToastLength.Short).Show();
            }
        }
        bool isValidUserName()
        {
            if (usernameEditText.Text == "")
            {
                usernameEditText.Error = "can't be empty!";
                return false;
            }
            return true;
        }
        bool isValidPassword()
        {
            if (passwordEditText.Text.Length < 8)
            {
                passwordEditText.Error = "must be 8 or of more characters!";
                return false;
            }
            return true;
        }
        public void uireferences()
        {
            forgotPasswordTextView = (TextView)FindViewById(Resource.Id.forgotPasswordTextView);
            loginTextView = (TextView)FindViewById(Resource.Id.haveNoAccountClickableTextView);
            usernameEditText = (EditText)FindViewById(Resource.Id.loginUserNameEditText);
            passwordEditText = (EditText)FindViewById(Resource.Id.loginPasswordEditText);
            loginButton = (Button)FindViewById(Resource.Id.loginButton);
            facbookIcon = (ImageButton)FindViewById(Resource.Id.facebookIconImageButton);
            googleIcon = (ImageButton)FindViewById(Resource.Id.googleIconImageButton);
        }
    }
}