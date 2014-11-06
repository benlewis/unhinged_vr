using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TextMesh))]
public class TextEditor : Editor {
	public override void OnInspectorGUI () {    
		this.DrawDefaultInspector();    
		TextMesh current_target = target as TextMesh;
		
		EditorGUILayout.LabelField("   Text:", "");
		
		current_target.text = EditorGUILayout.TextArea( current_target.text,GUILayout.MaxHeight(500f));        
	}
}