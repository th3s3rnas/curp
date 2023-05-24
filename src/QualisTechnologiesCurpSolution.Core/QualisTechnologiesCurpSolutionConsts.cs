using QualisTechnologiesCurpSolution.Debugging;

namespace QualisTechnologiesCurpSolution
{
    public class QualisTechnologiesCurpSolutionConsts
    {
        public const string LocalizationSourceName = "QualisTechnologiesCurpSolution";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "2cb6d7eac7e64bc38af44f9589af8f64";
    }
}
