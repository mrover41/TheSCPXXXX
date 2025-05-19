using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class AssemblyLoader : MonoBehaviour {
    const string MODS_PATH = "C:/ProgramFiles/TheSCPXXXX/Mods";
    static List<IPlugin> plugins = new();
    private void Start() {
        if (!Directory.Exists(MODS_PATH)) { 
            Directory.CreateDirectory(MODS_PATH);
        }

        string[] files = Directory.GetFiles(MODS_PATH, "*.dll");

        foreach (string file in files) {
            Assembly asm = Assembly.LoadFrom(file);
            System.Type a = asm.GetTypes().FirstOrDefault(x => typeof(IPlugin).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
            if (a != null) {
                IPlugin pluginInstance = (IPlugin)Activator.CreateInstance(a);
                if (plugins.Any(p => p.GetType() == pluginInstance.GetType())) continue;
                plugins.Add(pluginInstance);
                pluginInstance.OnEnable();
            }
            
        }
    }

    private void OnDisable() {
        foreach (IPlugin plugin in plugins) {
            plugin.OnDisable();
        }
    }
}
