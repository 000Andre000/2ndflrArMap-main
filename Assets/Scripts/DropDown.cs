using UnityEngine;
using TMPro;

public class DropDown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private NavMeshVisualizer navMeshVisualizer; // Reference to the NavMeshVisualizer script

    private void SetActionOfDropDown()
    {
        dropdown.onValueChanged.RemoveListener(SetSource);
        dropdown.onValueChanged.RemoveListener(SetDestination);
        dropdown.onValueChanged.AddListener(SetSource);
        dropdown.onValueChanged.AddListener(SetDestination);
    }

    public void SetSource(int selectedIndex)
    {
        Debug.Log("Source : " + selectedIndex);
        navMeshVisualizer.SetSource(selectedIndex);
    }

    public void SetDestination(int selectedIndex)
    {
        Debug.Log("Destination : " + selectedIndex);
        navMeshVisualizer.SetDestination(selectedIndex);
    }

    private void OnDestroy()
    {
        dropdown.onValueChanged.RemoveListener(SetSource);
        dropdown.onValueChanged.RemoveListener(SetDestination);
    }
}
