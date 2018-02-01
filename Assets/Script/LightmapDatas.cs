using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu (menuName = "Tino/LightmapData")]
public class LightmapDatas : ScriptableObject {

	LightmapData[] _lightmapData;
	LightmapsMode _lightmapsMode;

	Dictionary<int, GameobjectLightInfo> _gameobjectLightmapInfos = new Dictionary<int, GameobjectLightInfo> ();

	//use for gameobject
	public void AddLightmapInfo (int id, GameobjectLightInfo lightmapInfo) {

		if (_gameobjectLightmapInfos.ContainsKey (id)) {
			_gameobjectLightmapInfos.Remove (id);
		}

		_gameobjectLightmapInfos.Add (id, lightmapInfo);
	}

	public GameobjectLightInfo GetLigihtmapInfo (int id) {
		return _gameobjectLightmapInfos[id];
	}

	//use for screen
	public void GetLightmapSetting () {
		_lightmapData = LightmapSettings.lightmaps;
		_lightmapsMode = LightmapSettings.lightmapsMode;
	}

	public void SetLightmapSetting () {
		LightmapSettings.lightmaps = _lightmapData;
		LightmapSettings.lightmapsMode = _lightmapsMode;
	}

	public int GetLightmapCount () {
		if (_lightmapData != null)
			return _lightmapData.Length;

		return 0;
	}

	public void ClearLightmapData () {

		_gameobjectLightmapInfos = new Dictionary<int, GameobjectLightInfo> ();
		_lightmapData = null;
	}
}

public class GameobjectLightInfo {

	int _lightmapIndex;

	public int LightmapIndex {
		get { return _lightmapIndex; }
		set { _lightmapIndex = value; }
	}

	//Tiling X,Tiling Y, Offset X, Offset Y.
	Vector4 _lightmapOfferst;

	public Vector4 LightmapOfferst {
		get { return _lightmapOfferst; }
		set { _lightmapOfferst = value; }
	}

}

[CustomEditor (typeof (LightmapDatas))]
public class LightmapDatasEditor : Editor {

	public override void OnInspectorGUI () {
		DrawDefaultInspector ();

		LightmapDatas lightmapDatas = (LightmapDatas) target;

		GUILayout.TextField (lightmapDatas.GetLightmapCount ().ToString ());

		if (GUILayout.Button ("GetScreenLightmap")) {
			lightmapDatas.GetLightmapSetting ();
		}

		if (GUILayout.Button ("SetScreenLightmap")) {
			lightmapDatas.SetLightmapSetting ();
		}

		if (GUILayout.Button ("Clear")) {
			lightmapDatas.ClearLightmapData ();
		}
	}

}