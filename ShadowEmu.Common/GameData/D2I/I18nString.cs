#region License GNU GPL
// I18NString.cs
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

using System.ComponentModel;

namespace ShardowEditor.I18n
{
    internal class I18nString : INotifyPropertyChanged
    {
        private readonly I18nDataManager manager;
        private bool shouldRefresh = true;

        public I18nString(int id, I18nDataManager manager)
        {
            this.manager = manager;
            Id = id;
        }

        public I18nString(string id, I18nDataManager manager)
        {
            this.manager = manager;
            IdString = id;
        }

        /// <summary>
        /// Used if IdString == null
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// If null, Id is used
        /// </summary>
        public string IdString
        {
            get;
            set;
        }

        private string text;

        public string Text
        {
            get {
                if (shouldRefresh)
                    Refresh();

                return text; }
        }

        private Languages language;

        /// <summary>
        /// Default if null
        /// </summary>
        public Languages Language
        {
            get { return language; }
            set
            {
                if (language != value)
                    Refresh();
                language = value; 
            }
        }

        /// <summary>
        /// Update the Text property
        /// </summary>
        public void Refresh()
        {
            if (IdString != null)
                text = I18nDataManager.Instance.ReadText(IdString, Language);
            else
                text = I18nDataManager.Instance.ReadText(Id, Language);

            shouldRefresh = false;
        }

        public static implicit operator string(I18nString instance)
        {
            return instance.Text;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}