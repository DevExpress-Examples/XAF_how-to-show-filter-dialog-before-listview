using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;

namespace E1554.Module {
    [DefaultClassOptions]
    public class Employee : BaseObject {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Age { get; set; }
        public virtual IList<Task> Tasks { get; set; } = new ObservableCollection<Task>();
    }
}
