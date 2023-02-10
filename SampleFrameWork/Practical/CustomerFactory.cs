﻿using System;
using System.Configuration;
using SampleFrameWork.Practical;
using DataLayer;
using Utilities;
namespace UtilitiesLayer
{
    static class CustomerFactory
    {
        public static IDataComponent GetComponent(string type)
        {
            IDataComponent component = null;
            switch (type.ToLower())
            {
                case "list": return new Listcollection();
                case "arraylist": return new CustomerDatabase();
                default:
                    throw new CustomerException("This type is not supported by us");
            }
        }
    }
}  
