using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace E1554.Module {
    [DefaultProperty("FilterName")]
    public class ViewFilterObject : BaseObject {
        public ViewFilterObject(Session session) : base(session) { }

        private string dataTypeName;
        [Browsable(false)]
        public string DataTypeName {
            get { return dataTypeName; }
            set {
                Type type = XafTypesInfo.Instance.FindTypeInfo(value) == null ? null :
                    XafTypesInfo.Instance.FindTypeInfo(value).Type;
                if(dataType != type) {
                    dataType = type;
                }
                if(!IsLoading && value != dataTypeName) {
                    Criteria = string.Empty;
                }
                SetPropertyValue<string>(nameof(DataTypeName), ref dataTypeName, value);
            }
        }

        private Type dataType;
        [TypeConverter(typeof(LocalizedClassInfoTypeConverter))]
        [ImmediatePostData, NonPersistent]
        [Browsable(false)]
        public Type DataType {
            get { return dataType; }
            set {
                if(dataType != value) {
                    dataType = value;
                    DataTypeName = (value == null) ? null : value.FullName;
                }
            }
        }
        private string criteria;

        [CriteriaOptions(nameof(DataType))]
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.CriteriaPropertyEditor)]
        public string Criteria {
            get { return criteria; }
            set { SetPropertyValue<string>(nameof(Criteria), ref criteria, value); }
        }

        private string _FilterName;
        public string FilterName {
            get { return _FilterName; }
            set { SetPropertyValue(nameof(FilterName), ref _FilterName, value); }
        }
    }
}
