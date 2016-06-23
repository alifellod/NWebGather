using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
//////////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) 2014-2015, 王胜国
//  All rights reserved.
//  email 49480040@qq.com
//
//////////////////////////////////////////////////////////////////////////////////////
namespace NWebGather.Helper
{
    public class EscapeCharacterEntities
    {
        private static object _lookupLocker = new object();
        private static string[] _entitiesList = new string[]
    {
        "\n-n", 
        "\r-r",
        "\t-t", 
        "\f-f",           
        "\v-v" 
    };
        private static Hashtable _entitiesLoopupTable;
        private EscapeCharacterEntities() { }
        public static char Lookup(string entity)
        {
            if (_entitiesLoopupTable == null)
            {
                lock (_lookupLocker)
                {
                    if (_entitiesLoopupTable == null)
                    {
                        Hashtable curTable = new Hashtable();
                        foreach (string item in _entitiesList)
                        {
                            curTable[item.Substring(2)] = item[0];
                        }
                        _entitiesLoopupTable = curTable;
                    }
                }
            }
            object obj = _entitiesLoopupTable[entity];

            return obj == null ? (char)0 : (char)obj;
        }
    }
}
