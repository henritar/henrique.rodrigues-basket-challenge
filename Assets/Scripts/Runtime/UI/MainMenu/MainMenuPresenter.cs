using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;

namespace Assets.Scripts.Runtime.UI.MainMenu
{
    public class MainMenuPresenter : BasePresenter<IMainMenuModel, IMainMenuView>, IMainMenuPresenter
    {
        public MainMenuPresenter(IMainMenuModel model, IMainMenuView view) : base(model, view)
        {
        }

        public void ShowUI(bool show)
        {
            switch (show)
            {
                case true:
                    View.Show();
                    break;
                case false:
                    View.Hide();
                    break;
            }

            Model.IsUIVisible = show;
        } 
        
        protected override void Initialize()
        {
           View.Hide();
        }

        protected override void SubscribeToEvents()
        {
            View.SetStartButtonListener(() => {});
            View.SetQuitButtonListener(() => {});
        }

        protected override void UnsubscribeFromEvents()
        {
        }
    }
}