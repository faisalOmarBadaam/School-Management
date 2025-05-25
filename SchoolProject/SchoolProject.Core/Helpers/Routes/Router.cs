namespace SchoolProject.Core.Helpers.Routes
{
    public static class Router
    {
        const string Root = "Api";
        const string Version = "V1";
        const string Rule = Root + "/" + Version + "/";

        public static class StudentRouting
        {
            const string Prefixe = Rule + "Students";
            public const string List = Prefixe;
            public const string ByID = Prefixe + "/id";
            public const string Add = Prefixe;
            public const string Edit = Prefixe;
            public const string DeleteById = Prefixe + "/id";



        }


    }
}
