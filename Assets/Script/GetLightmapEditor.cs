using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (GameObjectLightmap))]
public class GetLightmapEditor : Editor {

	public override void OnInspectorGUI () {

		DrawDefaultInspector ();

		GameObjectLightmap getLightmap = (GameObjectLightmap) target;

		if (GUILayout.Button ("GetLightmap")) {
			getLightmap.GetGameObjectLightmapInfo ();
		}

		if (GUILayout.Button ("SetLightmap")) {
			getLightmap.SetGameObjectLightmapInfo ();
		}

	}

}