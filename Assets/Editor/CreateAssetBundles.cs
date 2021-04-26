using UnityEditor;
using UnityEngine;

public class CreateAssetBundles
{
    [MenuItem("Build AssetBundles/windows")]
    static void BuildAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles/BuildedAssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
