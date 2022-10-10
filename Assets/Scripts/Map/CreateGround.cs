using UnityEngine;

public class CreateGround : MonoBehaviour
{
    public Object groundPrefab;
    public int count;
    public Vector3 position;
    public float offset;
    public string objName;
    public enum DirType { X, Z };
    public DirType dirType;
    public void MakeRoad()
    {
        if (dirType == DirType.X)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject newGround = Instantiate(groundPrefab, position + new Vector3(position.x + i * offset, 0, position.z), Quaternion.identity) as GameObject;
                newGround.name = objName;
                newGround.transform.parent = this.transform;
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                GameObject newGround = Instantiate(groundPrefab, position + new Vector3(position.x, 0, position.z + i * offset), Quaternion.identity) as GameObject;
                newGround.name = objName;
                newGround.transform.parent = this.transform;
            }
        }
    }
}
