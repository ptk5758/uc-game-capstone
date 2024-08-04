using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class CharacterSystem : ICharacterSystem
    {
        public static event Action<GameObject> SpawnedCharacter;
        public GameObject SpawnCharacter(Transform location, GameObject character)
        {
            GameObject created = GameObject.Instantiate(character);
            created.transform.position = location.position;

            SpawnedCharacter?.Invoke(created);
            return created;
        }
        
    }
    public interface ICharacterSystem
    {
        public GameObject SpawnCharacter(Transform location, GameObject character);
    }
}