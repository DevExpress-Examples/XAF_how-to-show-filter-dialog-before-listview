using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using E1554.Module;

namespace DialogBeforeListViewEF.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();
        CreateTask("Task 1");
        CreateTask("Task 2");
        CreateTask("Task 3");
        CreateEmployee(20);
        CreateEmployee(30);
        CreateEmployee(40);
        ObjectSpace.CommitChanges();
    }
    private void CreateTask(string name) {
        E1554.Module.Task master = ObjectSpace.FirstOrDefault<E1554.Module.Task>(t => t.Name == name);
        if(master == null) {
            master = ObjectSpace.CreateObject<E1554.Module.Task>();
            master.Name = name;
        }
    }
    private void CreateEmployee(int value) {
        Employee detail = ObjectSpace.FirstOrDefault<Employee>(e => e.LastName == $"LastName {value}");
        if(detail == null) {
            detail = ObjectSpace.CreateObject<Employee>();
            detail.LastName = $"LastName {value}";
            detail.FirstName = $"FirstName {value}";
            detail.Age = value;
        }
    }
    public override void UpdateDatabaseBeforeUpdateSchema() {
        base.UpdateDatabaseBeforeUpdateSchema();
    }
}
