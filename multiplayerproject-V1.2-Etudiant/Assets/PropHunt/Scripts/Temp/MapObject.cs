using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct MapObject
{
    public string ObjectID; // Un identifiant unique pour chaque type d'objet
    public Vector3 Position; // Position de l'objet dans la carte
    public Quaternion Rotation; // Rotation de l'objet
    public Vector3 Scale; // Échelle de l'objet

    public MapObject(string id, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        ObjectID = id;
        Position = position;
        Rotation = rotation;
        Scale = scale;
    }
}