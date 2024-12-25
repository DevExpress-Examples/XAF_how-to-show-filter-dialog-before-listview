using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace E1554.Module {
    [DefaultClassOptions]
    public class Employee : BaseObject {
        public Employee(Session session) : base(session) { }

        private string firstName;
        public string FirstName {
            get { return firstName; }
            set { SetPropertyValue(nameof(FirstName), ref firstName, value); }
        }

        private string lastName;
        public string LastName {
            get { return lastName; }
            set { SetPropertyValue(nameof(LastName), ref lastName, value); }
        }

        private int age;
        public int Age {
            get { return age; }
            set { SetPropertyValue(nameof(Age), ref age, value); }
        }

        [Association("Employee-Task")]
        public XPCollection<Task> Tasks {
            get {
                return GetCollection<Task>(nameof(Tasks));
            }
        }
    }
}
