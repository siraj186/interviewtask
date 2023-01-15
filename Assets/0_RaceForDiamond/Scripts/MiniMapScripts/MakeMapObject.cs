using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RaceForDiamond
{
	public class MakeMapObject : MonoBehaviour
	{
		[SerializeField] private Image image;
		void Start() => MiniMapController.RegisterMapObject(this.gameObject, image);
		void OnDestroy() => MiniMapController.RemoveMapObject(this.gameObject);
		void OnDisable() => MiniMapController.RemoveMapObject(this.gameObject);
	}

}