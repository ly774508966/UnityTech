using UnityEngine;
using System.Collections;
using UnityEditor;

public class For_AssetBundle {

	[MenuItem("Publish/ThirdPerson")]
	public static void ThirdPerson()
	{
		AssetBundleBuild[] bundles = new AssetBundleBuild[1];
		bundles[0].assetBundleName = "ThirdPerson.unity3d";

		string[] strBundlesName = new string[1];
		strBundlesName[0] = "Assets/Resources/Characters/ThirdPersonCharacter/Prefabs/ThirdPersonController.prefab";

		bundles[0].assetNames = strBundlesName;

		BuildPipeline.BuildAssetBundles( "Assets/Bundles/", bundles );
		
	}
}
