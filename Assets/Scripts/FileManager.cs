using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class FileManager
{
    private static string[] ReadFile(string path)
    {
        // Read each line of the file into a string array. Each element
        // of the array is one line of the file.
        string[] lines = System.IO.File.ReadAllLines(@path);
        return lines;
    }
    //Separates the data from text file into coresponding data structures
    public static void RetriveModelData(string path,out List<Vect4> vertices, out List<int> indices)
    {
        string[] fileData=ReadFile(path);
        vertices = new List<Vect4>();
        indices = new List<int>();
        foreach (string dataRow in fileData)
        {
            if (dataRow.Length > 1)
            {
                if (dataRow[0].Equals('f')|| dataRow[0].Equals('v'))
                {
                    string[] words = dataRow.Split(' ');
                    if (words.Length==4)
                    {
                        if (words[0].Equals("v"))
                        {
                            vertices.Add(new Vect4(words[1], words[2], words[3]));
                        }
                        else if (words[0].Equals("f"))
                        {
                            indices.Add(Int32.Parse(words[1]));
                            indices.Add(Int32.Parse(words[2]));
                            indices.Add(Int32.Parse(words[3]));
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Invalid Row format: "+dataRow);
                    }

                }
            }
        }

    }   
}
