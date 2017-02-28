using UnityEngine;
using System.Collections;

public class ResourcesMemory_Test : MonoBehaviour {

	private AssetBundle assetBundle;
	private GameObject objPrefab;
	private GameObject objIns;

	void Start () {
	
		assetBundle = null;
		objPrefab = null;
		objIns = null;
	}

	void OnGUI(){

		GUI.Box ( new Rect (10,10,360,240), "Menu");

		if (GUI.Button ( new Rect (20,40,120,20), "Load AssetBundle")) {

			if (!assetBundle) {

				StartCoroutine (Load ());
			}
		}

		if (GUI.Button ( new Rect (20,70,120,20), "Load Asset")) {

			if (assetBundle && !objPrefab) {
			
				objPrefab = assetBundle.LoadAsset<GameObject>("ThirdPersonController.prefab");
				//Debug.Log (objPrefab);
			}
		}

		if (GUI.Button ( new Rect (160,40,120,20), "Instantiate")) {

			if (objPrefab && !objIns) {

				objIns = Instantiate<GameObject> (objPrefab);
				objIns.transform.position = Vector3.zero;
				//Debug.Log (objIns);
			}
		}

		if (GUI.Button ( new Rect (160,70,120,20), "Destroy")) {

			if (objIns) {

				Destroy (objIns);
			}
		}

		if (GUI.Button ( new Rect (20,100,200,20), "AssetBundle Unload(false)")) {

			if (assetBundle) {

				assetBundle.Unload (false);

				assetBundle = null;
			}
		}

		if (GUI.Button ( new Rect (20,130,200,20), "AssetBundle Unload(true)")) {

			if (assetBundle) {
			
				assetBundle.Unload (true);

				assetBundle = null;
				objPrefab = null;
			}

		}

		if (GUI.Button ( new Rect (20,160,340,20), "UnloadUnusedAssets(Keep the resource reference)")) {

		
			Resources.UnloadUnusedAssets ();
		}

		if (GUI.Button ( new Rect (20,190,340,20), "UnloadUnusedAssets(Remove the resource reference)")) {

			objPrefab = null;

			Resources.UnloadUnusedAssets ();
		}

	}

	IEnumerator Load()
	{
		WWW www = new WWW ("file://" + Application.dataPath + "/Bundles/ThirdPerson.unity3d");

		yield return www;

		assetBundle = www.assetBundle;
		//Debug.Log (assetBundle);
	}

}
