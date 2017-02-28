using UnityEngine;
using System.Collections;

public class CombineMesh_Test : MonoBehaviour {

	public bool originalState = false;

	void Start () {
	
		MeshRenderer[] mrs 	= gameObject.GetComponentsInChildren<MeshRenderer> ();
		Material[] mats 	= new Material[ mrs.Length ];

		int i = 0;
		for (; i < mrs.Length; ++i) {
		
			mats [i] = mrs [i].sharedMaterial;
		}

		// -----------------------

		MeshFilter[] mfs 		= gameObject.GetComponentsInChildren<MeshFilter> ();
		CombineInstance[] cis 	= new CombineInstance[ mfs.Length ];


		for (i = 0; i < mfs.Length; ++i) {
		
			cis [i].mesh 		= mfs [i].sharedMesh;
			cis [i].transform 	= mfs [i].transform.localToWorldMatrix;

			// 1. Just Hide Childrens.
			{
				// mfs [i].gameObject.SetActive (false);
			}

			// 2. Destroy Childrens.
			{
				if (mfs [i].gameObject.transform.name != gameObject.transform.name) {
				
					Destroy (mfs [i].gameObject);
				}
			}
		}

		// -----------------------

		transform.GetComponent<MeshFilter> ().mesh = new Mesh ();
		transform.GetComponent<MeshFilter> ().mesh.CombineMeshes (cis, false);

		transform.GetComponent<MeshRenderer> ().sharedMaterials = mats;

		// To restore the original state.
		if( true == originalState ){

			transform.localScale = Vector3.one;
		}
	}
}
