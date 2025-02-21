using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using System.ComponentModel;

namespace E1554.Module {
    [DomainComponent]
    public class ViewFilterContainer : NonPersistentBaseObject {
        private ViewFilterObject filter;

        [DataSourceProperty(nameof(Filters))]
        [ImmediatePostData]
        public ViewFilterObject Filter {
            get { return filter; }
            set { filter = value; }
        }
        private IList<ViewFilterObject> filters;
        [Browsable(false)]
        public IList<ViewFilterObject> Filters {
            get {
                if(filters == null && ObjectType != null) {
                    filters = objectSpace.GetObjects<ViewFilterObject>(CriteriaOperator.FromLambda<ViewFilterObject>(v => v.DataTypeName == ObjectType.FullName));
                }
                return filters;
            }
        }
        [CriteriaOptions(nameof(ObjectType))]
        [Browsable(false)]
        public string Criteria {
            get { return Filter != null ? Filter.Criteria : string.Empty; }
            set {
                if(Filter != null) {
                    Filter.Criteria = value;
                }
            }
        }
        private Type objectType;
        [Browsable(false)]
        public Type ObjectType {
            get { return objectType; }
            set { objectType = value; }
        }
        private IObjectSpace objectSpace;
        IObjectSpace IObjectSpaceLink.ObjectSpace {
            get {
                return objectSpace;
            }
            set {
                objectSpace = value;
            }
        }
    }
}
