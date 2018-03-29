using UnityEngine;
using UnityEditor;

public class ExportAssetBundles : MonoBehaviour {

    [MenuItem("Assets/Build AssetBundles From Selection - Track dependencies")]
    static void ExportResource()
    {
        string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "unity3d");

        if (path.Length != 0)
        {
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.Android);
            Selection.objects = selection;
        }
    }
}
