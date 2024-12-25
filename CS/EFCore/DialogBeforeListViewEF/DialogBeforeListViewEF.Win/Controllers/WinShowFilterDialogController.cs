using DevExpress.ExpressApp.Win;

namespace E1554.Module.Win {
    public class WinShowFilterDialogController : ShowFilterDialogController {
        protected override void ShowFilterDialogOnActivated() { }
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            ((WinWindow)Frame).Form.Shown += Form_Shown;
        }
        private void Form_Shown(object sender, EventArgs e) {
            ShowFilterDialog();
        }
    }
}
