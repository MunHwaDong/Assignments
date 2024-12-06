using UnityEditor;
using UnityEngine;

public class LevelDesignTool : EditorWindow
{
    public GameObject prefabToPlace;

    private int numberOfObjects = 10;
    private float areaSize = 10f;

    [MenuItem("Window/Level Design Tool")]
    public static void ShowWindow()
    {
        GetWindow<LevelDesignTool>("Level Design Tool");
    }

    private void OnGUI()
    {
        GUILayout.Label("Prefab Placement Tool", EditorStyles.boldLabel);
        
        //Prefabs 선택 필드
        prefabToPlace = (GameObject)EditorGUILayout.ObjectField("Prefab to Place", prefabToPlace, typeof(GameObject), false);
        
        //배치 옵션 설정 GUI
        numberOfObjects = EditorGUILayout.IntField("Number of Objects", numberOfObjects);
        areaSize = EditorGUILayout.FloatField("Area Size", areaSize);
        
        //배치 버튼
        if (GUILayout.Button("Place Objects"))
        {
            if (prefabToPlace != null)
                PlaceObjects();
            else
                EditorUtility.DisplayDialog("Error", "Please assign a prefab to place.", "OK");
        }
    }

    private void PlaceObjects()
    {
        // 선택된 개수만큼 오브젝트를 랜덤한 위치에 배치
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-areaSize / 2, areaSize / 2),
                0,
                Random.Range(-areaSize / 2, areaSize / 2)
            );

            // Scene에 프리팹 생성
            GameObject newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefabToPlace);
            newObject.transform.position = randomPosition;

            // 생성된 오브젝트를 Undo로 관리 가능하게 설정 (Ctrl+Z로 되돌리기 가능)
            Undo.RegisterCreatedObjectUndo(newObject, "Place Prefab");
        }
    }
}
