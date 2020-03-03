namespace Lab2.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        public MainViewModel()
        {
            Login = new LoginViewModel();
        }
    }
}
