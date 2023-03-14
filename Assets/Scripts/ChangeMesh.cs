using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ChangeMesh : MonoBehaviour
{
    [SerializeField] List<Mesh> _meshes = new List<Mesh>();

    MeshFilter _meshFilter;
    int _currentMesh = 0;

    void OnValidate()
    {
        if (!_meshes.Contains(GetComponent<MeshFilter>().sharedMesh))
        {
            _meshes.Insert(0, GetComponent<MeshFilter>().sharedMesh);
        }
    }
    
    void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.mesh = _meshes[0];
    }

    public void NextMesh()
    {
        _currentMesh++;
        if (_currentMesh >= _meshes.Count)
        {
            _currentMesh = 0;
        }
        _meshFilter.mesh = _meshes[_currentMesh];
    }

    public void PreviousMesh()
    {
        _currentMesh--;
        if (_currentMesh < 0)
        {
            _currentMesh = _meshes.Count - 1;
        }
        _meshFilter.mesh = _meshes[_currentMesh];
    }

    public bool SetMesh(int index)
    {
        if (index < _meshes.Count)
        {
            _meshFilter.mesh = _meshes[index];
            return true;
        }
        else
        {
            Debug.Log("Index out of bounds!");
            return false;
        }
    }
}