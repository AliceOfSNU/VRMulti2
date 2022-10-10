using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreateGround))]
public class GroundSpawnEditor : Editor
{
    CreateGround createGround;
    private void OnEnable()
    {
        createGround = (CreateGround)target;

    }
    public override void OnInspectorGUI()
    {
        createGround.groundPrefab = EditorGUILayout.ObjectField("생성할 오브제", createGround.groundPrefab, typeof(Object), true);

        GUILayout.BeginHorizontal();
        createGround.count = EditorGUILayout.IntField("생성할 오브제의 개수", createGround.count);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.FlexibleSpace();

        GUILayout.BeginHorizontal();
        createGround.position = EditorGUILayout.Vector3Field("생성할 오브제의 위치", createGround.position);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal();
        createGround.offset = EditorGUILayout.FloatField("생성될 오브제의 간격", createGround.offset);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        createGround.objName = EditorGUILayout.TextField("생성될 오브제의 이름", createGround.objName);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        createGround.dirType = (CreateGround.DirType)EditorGUILayout.EnumPopup("생성할 오브제의 방향", createGround.dirType);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Make"))
        {
            createGround.MakeRoad();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

    }

}
