#region License GNU GPL
// D2oFieldDefinition.cs
// 
// Copyright (C) 2012 - BehaviorIsManaged
// 
// This program is free software; you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details. 
// You should have received a copy of the GNU General Public License along with this program; 
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
#endregion
using System;
using System.Reflection;

namespace ShadowEmu.Common.GameData.D2O
{
    public class D2oFieldDefinition
    {
        public D2oFieldDefinition(string name, D2oFieldType typeId, FieldInfo fieldInfo, long offset, params Tuple<D2oFieldType, string>[] vectorsTypes)
        {
            Name = name;
            TypeId = typeId;
            FieldInfo = fieldInfo;
            Offset = offset;

            VectorTypes = vectorsTypes;
        }

        public D2oFieldDefinition(string name, D2oFieldType typeId, PropertyInfo propertyInfo, long offset, params Tuple<D2oFieldType, string>[] vectorsTypes)
        {
            Name = name;
            TypeId = typeId;
            PropertyInfo = propertyInfo;
            Offset = offset;

            VectorTypes = vectorsTypes;
        }

        public string Name
        {
            get;
            set;
        }

        public D2oFieldType TypeId
        {
            get;
            set;
        }

        public Tuple<D2oFieldType, string>[] VectorTypes
        {
            get;
            set;
        }

        internal long Offset
        {
            get;
            set;
        }

        public Type FieldType
        {
            get
            {
                return PropertyInfo != null ? PropertyInfo.PropertyType : FieldInfo.FieldType;
            }
        }

        internal PropertyInfo PropertyInfo
        {
            get;
            set;
        }

        internal FieldInfo FieldInfo
        {
            get;
            set;
        }

        public object GetValue(object instance)
        {
            if (PropertyInfo != null)
                return PropertyInfo.GetValue(instance, null);
            else if (FieldInfo != null)
                return FieldInfo.GetValue(instance);
            else
            {
                throw new NullReferenceException();
            }
        }

        public void SetValue(object instance, object value)
        {
            if (PropertyInfo != null)
                PropertyInfo.SetValue(instance, value, null);
            else if (FieldInfo != null)
                FieldInfo.SetValue(instance, value);
        }
    }
}