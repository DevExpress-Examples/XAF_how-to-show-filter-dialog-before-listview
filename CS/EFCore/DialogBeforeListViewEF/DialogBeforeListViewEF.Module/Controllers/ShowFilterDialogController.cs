using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DialogBeforeListViewEF.Module;

namespace E1554.Module {
    public class ShowFilterDialogController : ViewController<ListView> {
        const string DisableReason = "SuitableView";
        SimpleAction showFilterDialogAction;
        public ShowFilterDialogController() {
            TargetViewNesting = Nesting.Root;
            showFilterDialogAction = new SimpleAction(this, "ShowFilterDialog", PredefinedCategory.Filters);
            showFilterDialogAction.Execute += ShowFilterDialogAction_Execute;
        }
        protected override void OnActivated() {
            base.OnActivated();
            if(Frame.Context == TemplateContext.ApplicationWindow || Frame.Context == TemplateContext.View) {
                showFilterDialogAction.Active[DisableReason] = true;
                View.CollectionSource.Criteria[nameof(ShowFilterDialogController)] = CollectionSourceBase.EmptyCollectionCriteria;
                ShowFilterDialogOnActivated();
            } else {
                showFilterDialogAction.Active[DisableReason] = false;
            }
        }
        protected virtual void ShowFilterDialogOnActivated() {
            ShowFilterDialog();
        }
        private void ShowFilterDialogAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            ShowFilterDialog();
        }
        protected void ShowFilterDialog() {
            NonPersistentObjectSpace nonPersistentObjectSpace = (NonPersistentObjectSpace)Application.CreateObjectSpace<ViewFilterContainer>();
            IObjectSpace persistentObjectSpace = Application.CreateObjectSpace<ViewFilterObject>();
            nonPersistentObjectSpace.AdditionalObjectSpaces.Add(persistentObjectSpace);
            ViewFilterContainer newViewFilterContainer = nonPersistentObjectSpace.CreateObject<ViewFilterContainer>();
            newViewFilterContainer.ObjectType = View.ObjectTypeInfo.Type;
            newViewFilterContainer.Filter = GetFilterObject(persistentObjectSpace, ((IModelListViewAdditionalCriteria)View.Model).AdditionalCriteria, newViewFilterContainer.ObjectType);
            DetailView filterDetailView = Application.CreateDetailView(nonPersistentObjectSpace, newViewFilterContainer);
            filterDetailView.Caption = string.Format("Filter for the {0} ListView", View.Caption);
            Application.ShowViewStrategy.ShowViewInPopupWindow(filterDetailView, () => FilterDetailView_OK(filterDetailView));
        }
        private void FilterDetailView_OK(DetailView filterDetailView) {
            filterDetailView.ObjectSpace.CommitChanges();
            ViewFilterContainer currentViewFilterContainer = (ViewFilterContainer)filterDetailView.CurrentObject;
            ((IModelListViewAdditionalCriteria)View.Model).AdditionalCriteria = currentViewFilterContainer.Criteria;
            View.CollectionSource.Criteria[nameof(ShowFilterDialogController)] = CriteriaEditorHelper.GetCriteriaOperator(currentViewFilterContainer.Criteria, currentViewFilterContainer.ObjectType, ObjectSpace);
        }
        private ViewFilterObject GetFilterObject(IObjectSpace objectSpace, string listViewCriteria, Type objectType) {
            ViewFilterObject filterObject = objectSpace.FirstOrDefault<ViewFilterObject>(fo => fo.Criteria == listViewCriteria && fo.DataTypeName == objectType.FullName);
            if(filterObject == null) {
                filterObject = objectSpace.FirstOrDefault<ViewFilterObject>(fo => fo.FilterName == "All" && fo.DataTypeName == objectType.FullName);
                if(filterObject == null) {
                    ViewFilterObject newFilterObject = objectSpace.CreateObject<ViewFilterObject>();
                    newFilterObject.DataType = objectType;
                    newFilterObject.FilterName = "All";
                    objectSpace.CommitChanges();
                    filterObject = objectSpace.GetObject(newFilterObject);
                }
                filterObject.DataType = objectType;
                filterObject.Criteria = listViewCriteria;
            }
            return filterObject;
        }
    }
}
