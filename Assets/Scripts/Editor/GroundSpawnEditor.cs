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
        createGround.groundPrefab = EditorGUILayout.ObjectField("������ ������", createGround.groundPrefab, typeof(Object), true);

        GUILayout.BeginHorizontal();
        createGround.count = EditorGUILayout.IntField("������ �������� ����", createGround.count);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.FlexibleSpace();

        GUILayout.BeginHorizontal();
        createGround.position = EditorGUILayout.Vector3Field("������ �������� ��ġ", createGround.position);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal();
        createGround.offset = EditorGUILayout.FloatField("������ �������� ����", createGround.offset);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        createGround.objName = EditorGUILayout.TextField("������ �������� �̸�", createGround.objName);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        createGround.dirType = (CreateGround.DirType)EditorGUILayout.EnumPopup("������ �������� ����", createGround.dirType);
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
