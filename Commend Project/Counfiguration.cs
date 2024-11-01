namespace Commend_Project
{
    public static class Counfiguration
    {
        public static string ConnctionString { get; set; }
        static Counfiguration()
        {
            ConnctionString = "Data Source = DESKTOP-J6I42F2\\SQLEXPRESS ;Initial Catalog = Commend Project ;User id = SA ;Password = 123456;TrustServerCertificate = True;";
        }
    }
}
