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
        var store = Lesson1.CreateStore();
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
