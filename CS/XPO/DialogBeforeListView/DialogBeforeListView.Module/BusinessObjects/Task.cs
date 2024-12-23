using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace E1554.Module {
    [DefaultClassOptions]
    public class Task : BaseObject {
        public Task(Session session) : base(session) { }

        private string name;
        public string Name {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }

        [Association("Employee-Task")]
        public XPCollection<Employee> Employees {
            get {
                return GetCollection<Employee>(nameof(Employees));
            }
        }
    }

}