using System.Threading.Tasks;
using Xamarin.Forms;

namespace SluttaShell
{
    public static class ModalHelpers
    {
        // Not happy to add this, but releasing was more important that fighting the platform specific weirdness
        // we were seeing in modal behavior between iOS & Android. Hopefully you can ditch this with whatever
        // version of Xamarin you are now on.
        public static async Task PopAllModals()
        {
            int numModals = Application.Current.MainPage.Navigation.ModalStack.Count;
            for (int currModal = 0; currModal < numModals; currModal++)
            {
                await Application.Current.MainPage.Navigation.PopModalAsync(animated: false);
            }
        }
    }
}
