using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace E1554.Module {
    [DefaultProperty(nameof(FilterName))]
    public class ViewFilterObject : BaseObject {
        public virtual string FilterName { get; set; }

        [Browsable(false)]
        public virtual string DataTypeName {
            get { return fDataType == null ? string.Empty : fDataType.FullName; }
            set {
                ITypeInfo typeInfo = XafTypesInfo.Instance.FindTypeInfo(value);
                fDataType = typeInfo == null ? null : typeInfo.Type;
            }
        }

        private Type fDataType;
        [NotMapped, ImmediatePostData]
        [Browsable(false)]
        public Type DataType {
            get { return fDataType; }
            set {
                if(fDataType == value) return;
                fDataType = value;
                Criteria = string.Empty;
            }
        }

        [CriteriaOptions(nameof(DataType))]
        [FieldSize(FieldSizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.CriteriaPropertyEditor)]
        public virtual string Criteria { get; set; }
    }
}
