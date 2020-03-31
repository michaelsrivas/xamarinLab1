namespace Lab2.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
        public MainViewModel()
        {
            Login = new LoginViewModel();
        }
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            
            return instance;
        }
    }
}
