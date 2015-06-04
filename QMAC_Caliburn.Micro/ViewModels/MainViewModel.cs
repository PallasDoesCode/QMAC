using Caliburn.Micro;

namespace QMAC_Caliburn.Micro.ViewModels
{
    public class MainViewModel : PropertyChangedBase, IHaveDisplayName
    {
        public MainViewModel()
        {
            DisplayName = "QMAC";
        }

        /// <summary>
        /// Gets or Sets the Display Name
        /// </summary>
        public string DisplayName { get; set; }
    }
}
