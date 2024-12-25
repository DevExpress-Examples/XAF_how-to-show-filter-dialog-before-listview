using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;

namespace E1554.Module {
    [DefaultClassOptions]
    public class Task : BaseObject {
        public virtual string Name { get; set; }
        public virtual IList<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
    }

}