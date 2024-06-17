using Xbim.Ifc;
using Xbim.Ifc4x3.GeometryResource;

namespace xBim.Tutorial;
internal static class Lesson2
{
    private const string PATH = "E:\\Desktop\\test\\second.ifc";

    public static void Create()
    {
        var store = CreateStore();
        store.SaveAs(PATH);
    }

    public static IfcStore CreateStore()
    {
        var credit = new XbimEditorCredentials()
        {
            ApplicationDevelopersName = "秋水",
            ApplicationFullName = "xBIM tutorial",
            ApplicationIdentifier = "xBIM_Tutorial",
            ApplicationVersion = "1.0",
            EditorsFamilyName = "李",
            EditorsGivenName = "秋水",
            EditorsOrganisationName = "秋水工作室",
        };

        var store = IfcStore.Create(credit, Xbim.Common.Step21.XbimSchemaVersion.Ifc4x3, Xbim.IO.XbimStoreType.EsentDatabase);

        AddAxis(store);

        return store;
    }

    private static void AddAxis(IfcStore store)
    {
        using var trans = store.BeginTransaction();

        var axis = store.Instances.New<IfcAxis2Placement3D>();

        var location = store.Instances.New<IfcCartesianPoint>();
        location.Coordinates.AddRange([0, 0, 0]);

        axis.Location = location;

        var z = store.Instances.New<IfcDirection>();
        z.DirectionRatios.AddRange([0, 0, 1]);
        axis.Axis = z;

        var x = store.Instances.New<IfcDirection>();
        x.DirectionRatios.AddRange([1, 0, 0]);
        axis.RefDirection = x;

        trans.Commit();
    }
}
