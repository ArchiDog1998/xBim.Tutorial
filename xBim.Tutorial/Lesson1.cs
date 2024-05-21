using Xbim.Ifc;
using Xbim.Ifc4x3.ActorResource;
using Xbim.Ifc4x3.UtilityResource;

namespace xBim.Tutorial;
internal class Lesson1
{
    private const string PATH = "E:\\Desktop\\test\\first.ifc";

    /// <summary>
    /// Create and save.
    /// </summary>
    public static void Section1()
    {
        var store = IfcStore.Create(Xbim.Common.Step21.XbimSchemaVersion.Ifc4x3, Xbim.IO.XbimStoreType.EsentDatabase);

        store.SaveAs(PATH);
    }

    /// <summary>
    /// Transaction, new entity and Ifc Value.
    /// </summary>
    public static void Section2()
    {
        var store = IfcStore.Create(Xbim.Common.Step21.XbimSchemaVersion.Ifc4x3, Xbim.IO.XbimStoreType.EsentDatabase);

        using (var trans = store.BeginTransaction("Create the application"))
        {
            var app = store.Instances.New<IfcApplication>();
            app.ApplicationIdentifier = "xBimGH";
            app.ApplicationFullName = "xBim GH";

            trans.Commit();
        }

        store.SaveAs(PATH);
    }

    /// <summary>
    /// Add entity in the entity!
    /// </summary>
    public static void Section3()
    {
        var store = IfcStore.Create(Xbim.Common.Step21.XbimSchemaVersion.Ifc4x3, Xbim.IO.XbimStoreType.EsentDatabase);

        using (var trans = store.BeginTransaction("Create the application"))
        {
            var app = store.Instances.New<IfcApplication>();
            app.ApplicationIdentifier = "xBimGH";
            app.ApplicationFullName = "xBim GH";

            var org = store.Instances.New<IfcOrganization>();
            org.Description = "Archi Dream Team";
            org.Identification = "ArchiCorp";
            app.ApplicationDeveloper = org;

            trans.Commit();
        }
        store.SaveAs(PATH);
    }

    /// <summary>
    /// InverseProperty
    /// </summary>
    public static void Section4()
    {
        var store = IfcStore.Create(Xbim.Common.Step21.XbimSchemaVersion.Ifc4x3, Xbim.IO.XbimStoreType.EsentDatabase);

        using (var trans = store.BeginTransaction("Create the application"))
        {
            var app = store.Instances.New<IfcApplication>();
            app.ApplicationIdentifier = "xBimGH";
            app.ApplicationFullName = "xBim GH";

            var org = store.Instances.New<IfcOrganization>();
            org.Description = "Archi Dream Team";
            org.Identification = "ArchiCorp";
            app.ApplicationDeveloper = org;

            //org.Engages.Add ????

            var personRel = store.Instances.New<IfcPersonAndOrganization>();
            personRel.TheOrganization = org;

            var person = store.Instances.New<IfcPerson>();
            personRel.ThePerson = person;

            person.FamilyName = "Qiu";
            person.GivenName = "Shui";

            trans.Commit();
        }
        store.SaveAs(PATH);
    }
}
