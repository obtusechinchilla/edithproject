using UnityEngine;
using System.Collections;
using UnityEditor;
using MapReader;

[CustomEditor(typeof(MapLoader))]
public class MapLoaderEditor : Editor {

	public override void OnInspectorGUI() {

		DrawDefaultInspector ();

		MapLoader mapLoader = (MapLoader)target;
		if (GUILayout.Button ("Load Map")) {
			mapLoader.LoadMap();
		}
	}
}
