using System;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameEventController
{
     private static readonly Dictionary<string, List<Action<String, object>>> listeners = new();

     public static void EmitEvent(String type, object payload){
        if(listeners.ContainsKey(type)){
        foreach(var action in listeners[type]){
            action(type, payload);
        }
        }
     }

     public static void AddListener(String type, Action<string, object> action){
        if(! listeners.ContainsKey(type)){
            listeners[type] = new List<Action<string, object>>();
        }

            listeners[type].Add(action);

     }

     public static void RemoveListener(String type, Action<string, object> action){
        if(listeners.ContainsKey(type)){
            listeners[type].Remove(action);
        }
     }
}
