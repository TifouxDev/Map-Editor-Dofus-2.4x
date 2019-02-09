#region License GNU GPL
// I18NDataManager.cs
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ComponentModel;
using ShadowEmu.Common.Extensions;
using ShadowEmu.Common.GameData.D2I;

namespace ShardowEditor.I18n
{
    public class I18nDataManager : DataManager<I18nDataManager>
    {
        public static readonly bool DelayLoading = true;

        private WeakCollection<I18nString> links = new WeakCollection<I18nString>();
        private Dictionary<Languages, D2iFile> readers = new Dictionary<Languages, D2iFile>();
        private static Dictionary<string, Languages> langsShortcuts = new Dictionary<string, Languages>()
        {
            {"fr", Languages.French},
            {"de", Languages.German},
            {"en", Languages.English},
            {"es", Languages.Spanish},
            {"it", Languages.Italian},
            {"ja", Languages.Japanese},
            {"nl", Languages.Dutch},
            {"pt", Languages.Portugese},
            {"ru", Languages.Russian},
        };

        Languages defaultLanguage = Languages.French;
        public Languages DefaultLanguage
        {
            get
            {
                return defaultLanguage;
            }
            set
            {
                defaultLanguage = value;
                EnsureLanguageIsLoaded(defaultLanguage);
            }
        }

        private void EnsureLanguageIsLoaded(Languages language)
        {
            if (readers.ContainsKey(language)) return;

            if (string.IsNullOrEmpty(d2IPath)) 
                return; // AddReaders not called yet
            foreach (var d2iFile in Directory.EnumerateFiles(d2IPath).Where(entry => entry.EndsWith(".d2i")).Where(path => GetLanguageOfFile(path) == language))
            {
                var reader = new D2iFile(d2iFile);
                AddReader(reader, language);
            }

            if (!readers.ContainsKey(language))
                throw new System.Exception(string.Format("Language {0} not found in the d2i files, check the path of these files and that the file exist ({1})", language, d2IPath));
        }
        private string d2IPath;
        public void AddReaders(string directory, bool forceLoading = true)
        {
               d2IPath = directory;
               if (forceLoading)
                foreach (string d2iFile in Directory.EnumerateFiles(directory).Where(entry => entry.EndsWith(".d2i")))
                {
                    var reader = new D2iFile(d2iFile);

                    AddReader(reader);
                }
        }

        private Languages GetLanguageOfFile(string filePath)
        {
            string file = Path.GetFileNameWithoutExtension(filePath);

            if (!file.Contains("_"))
                throw new System.Exception(string.Format("Cannot found character '_' in file name {0}, cannot deduce the file lang", file));

            string lang = file.Split('_')[1];

            if (!langsShortcuts.ContainsKey(lang.ToLower()))
                throw new System.Exception(string.Format("Unknown lang symbol {0} in file {1}", lang, file));
            return langsShortcuts[lang.ToLower()];
        }

        private void AddReader(D2iFile d2iFile)
        {
            Languages language = GetLanguageOfFile(d2iFile.FilePath);

            AddReader(d2iFile, language);
        }

        private void AddReader(D2iFile d2iFile, Languages language)
        {
            readers.Add(language, d2iFile);
        }

        public string ReadText(uint id, Languages? lang = null)
        {
            return ReadText((int)id, lang);
        }

        public string ReadText(int id, Languages? lang = null)
        {
            if (lang != null)
            {
                EnsureLanguageIsLoaded(lang.Value);
                return readers[lang.Value].GetText(id);
            }

            EnsureLanguageIsLoaded(DefaultLanguage);
            return readers[DefaultLanguage].GetText(id);
        }

        public string GetText(int id, Languages? lang = null)
        {
            if (lang != null)
            {
                EnsureLanguageIsLoaded(lang.Value);
                return readers[lang.Value].GetText(id);
            }

            EnsureLanguageIsLoaded(DefaultLanguage);
            return readers[DefaultLanguage].GetText(id);
        }

        public string ReadText(string id, Languages? lang = null)
        {
            if (lang != null)
            {
                EnsureLanguageIsLoaded(lang.Value);
                return readers[lang.Value].GetText(id);
            }

            EnsureLanguageIsLoaded(DefaultLanguage);
            return readers[DefaultLanguage].GetText(id);
        }

        public Dictionary<int, string> GetAllText(Languages? lang = null)
        {
            if (lang != null)
            {
                EnsureLanguageIsLoaded(lang.Value);
                return readers[lang.Value].GetAllText();
            }

            EnsureLanguageIsLoaded(DefaultLanguage);
            return readers[DefaultLanguage].GetAllText();
        }

        public Dictionary<int, string> GetAllTextWith(string name, Languages? lang = null)
        {
            if (lang != null)
            {
                EnsureLanguageIsLoaded(lang.Value);
                return readers[lang.Value].GetAllText();
            }

            EnsureLanguageIsLoaded(DefaultLanguage);
            var test = new Dictionary<int, string>();
            foreach (var item in readers[DefaultLanguage].GetAllText())
            {
                if (item.Value.ToLower().Contains(name.ToLower()))
                    test.Add(item.Key, item.Value);
            }
            return test;
        }

        public Dictionary<string, string> GetAllUITextWith(string name, Languages? lang = null)
        {
            EnsureLanguageIsLoaded(DefaultLanguage);
            var test = new Dictionary<string, string>();
            foreach (var item in readers[DefaultLanguage].GetAllUiText())
            {
                if (item.Value.ToLower().Contains(name.ToLower()))
                    test.Add(item.Key, item.Value);
            }
            return test;
        }

        public Dictionary<string, string> GetAllUIText(Languages? lang = null)
        {
            if (lang != null)
            {
                EnsureLanguageIsLoaded(lang.Value);
                return readers[lang.Value].GetAllUiText();
            }

            EnsureLanguageIsLoaded(DefaultLanguage);
            return readers[DefaultLanguage].GetAllUiText();
        }

        public void SetText(int id, string text, Languages? lang = null)
        {
            if (lang != null)
            {
                EnsureLanguageIsLoaded(lang.Value);
                readers[lang.Value].SetText(id, text);
            }

            EnsureLanguageIsLoaded(DefaultLanguage);
            readers[DefaultLanguage].SetText(id, text);
        }

        public void Save(Languages? lang = null)
        {
            if (lang != null)
            {
                EnsureLanguageIsLoaded(lang.Value);
                readers[lang.Value].Save();
            }

            EnsureLanguageIsLoaded(DefaultLanguage);
            readers[DefaultLanguage].Save();
        }

        public void RemoveText(int id, Languages? lang = null)
        {
            if (lang != null)
            {
                EnsureLanguageIsLoaded(lang.Value);
                readers[lang.Value].RemoveText(id);
            }

            EnsureLanguageIsLoaded(DefaultLanguage);
            readers[DefaultLanguage].RemoveText(id);
        }

        private I18nString GetTextLink(uint id, Languages? lang = null)
        {
            return GetTextLink((int)id);
        }

        private I18nString GetTextLink(int id, Languages? lang = null)
        {
            if (lang != null)
            {
                EnsureLanguageIsLoaded(lang.Value);
            }

            return new I18nString(id, this);
        }

        private I18nString GetTextLink(string id, Languages? lang = null)
        {
            if (lang != null)
            {
                EnsureLanguageIsLoaded(lang.Value);
            }

            return new I18nString(id, this);
        }

        private void ChangeLinksLanguage(Languages old, Languages @new)
        {
            foreach (var link in links.Where(x => x.Language == old))
            {
                // text refreshed when the language is changed
                link.Language = @new;
            }
        }

        private void RefreshLinks()
        {
            foreach (var link in links)
            {
                link.Refresh();
            }
        }
    }
}