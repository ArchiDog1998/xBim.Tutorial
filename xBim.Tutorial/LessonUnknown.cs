using Xbim.Ifc;
using Xbim.Ifc4x3.GeometricConstraintResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.SharedBldgElements;

namespace xBim.Tutorial;
internal static class LessonUnknown
{
    private const string PATH = "E:\\Desktop\\test\\third.ifc";

    public static void Create()
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

        ModifyIfcSotre(store);

        store.SaveAs(PATH);
    }

    private static void ModifyIfcSotre(IfcStore store)
    {
        using var trans = store.BeginTransaction();

        var column = store.Instances.New<IfcColumn>();
        column.Name = "My First Column";
        column.Description = "What a nice Column!";

        ModifyLocalPlaceMent(ref column, store);

        column.Tag = "This is an identifiker";
        column.PredefinedType = IfcColumnTypeEnum.COLUMN;

        trans.Commit();
    }

    private static void ModifyLocalPlaceMent(ref IfcColumn column, IfcStore store)
    {


        var localPlacement = store.Instances.New<IfcLocalPlacement>();
        column.ObjectPlacement = localPlacement;
        //localPlacement.RelativePlacement = new ifcaxis2placement
    }

    private static void CreateAxix2(IfcStore store)
    {
        var axix = store.Instances.New<IfcAxis2Placement3D>();

    }

}
