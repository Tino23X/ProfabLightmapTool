using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectLightmap : MonoBehaviour {


	[SerializeField]
	LightmapDatas _lightmapDatas;

	[SerializeField]
	//prefab need to use
	int _instanceID;

	public void GetGameObjectLightmapInfo () {

		if (_lightmapDatas == null)
		{
			Debug.LogError("There hasn't lightmap datas asset");
			return;
		}

		_instanceID = gameObject.GetInstanceID();

		GameobjectLightInfo objectLightInfo = new GameobjectLightInfo();

		MeshRenderer mr = this.GetComponent<MeshRenderer> ();
		objectLightInfo.LightmapIndex = mr.lightmapIndex;
		objectLightInfo.LightmapOfferst = mr.lightmapScaleOffset;

		_lightmapDatas.AddLightmapInfo(_instanceID, objectLightInfo);
	}

	public void SetGameObjectLightmapInfo () {

		if (_lightmapDatas == null)
		{
			Debug.LogError("There hasn't lightmap datas asset");
			return;
		}

		if (_instanceID == 0)
		{
			Debug.LogError("Bake screen, and set this gameobject lightmap");
			return;
		}

		MeshRenderer mr = this.GetComponent<MeshRenderer> ();
		GameobjectLightInfo objectLightInfo = _lightmapDatas.GetLigihtmapInfo(_instanceID);

		mr.lightmapIndex = objectLightInfo.LightmapIndex;
		mr.lightmapScaleOffset = objectLightInfo.LightmapOfferst;
	}

}