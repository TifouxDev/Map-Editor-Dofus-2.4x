using DesignEditeurMap.Extensions;
using ShadowEmu.Common.Protocol.Enums;
using ShadowEmu.World.Game.Characters.Look;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DesignEditeurMap.Look
{
    public class ActorLook
    {
        private System.Collections.Generic.Dictionary<int, Color> m_colors = new System.Collections.Generic.Dictionary<int, Color>();
        private System.Collections.Generic.List<short> m_scales = new System.Collections.Generic.List<short>();
        private System.Collections.Generic.List<short> m_skins = new System.Collections.Generic.List<short>();
        private System.Collections.Generic.List<SubActorLook> m_subLooks = new System.Collections.Generic.List<SubActorLook>();
        private short m_bonesID;
        public List<short> ItemsSkin { get; set; }
        public List<SubActorLook> SubLooks
        {
            get
            {
                return this.m_subLooks;
            }
        }
        public short BonesID
        {
            get
            {
                return this.m_bonesID;
            }
            set
            {
                this.m_bonesID = value;
            }
        }
        public List<short> Skins
        {
            get
            {
                return this.m_skins;
            }
        }
        public List<short> Scales
        {
            get
            {
                return this.m_scales;
            }
        }
        public Dictionary<int, Color> Colors
        {
            get
            {
                return this.m_colors;
            }
        }
        public ActorLook PetLook
        {
            get
            {
                SubActorLook subActorLook = this.m_subLooks.FirstOrDefault((SubActorLook x) => x.BindingCategory == SubEntityBindingPointCategoryEnum.HOOK_POINT_CATEGORY_PET);
                return (subActorLook != null) ? subActorLook.Look : null;
            }
        }
        public ActorLook()
        {
            ItemsSkin = new List<short>();
        }
        public bool IsMorph
        {
            get;
            set;
        }
        public ActorLook(short bones, IEnumerable<short> skins, Dictionary<int, Color> indexedColors, IEnumerable<short> scales, IEnumerable<SubActorLook> subLooks, bool isMorph)
        {
            this.m_bonesID = bones;
            this.m_skins = skins.ToList<short>();
            this.m_colors = indexedColors;
            this.m_scales = scales.ToList<short>();
            this.m_subLooks = subLooks.ToList<SubActorLook>();
            ItemsSkin = new List<short>();
            IsMorph = isMorph;
        }
        public static ActorLook Parse(string str, bool isMorph = false)
        {
            if (string.IsNullOrEmpty(str) || str[0] != '{')
            {
                NLog.LogManager.GetCurrentClassLogger().Error("Incorrect EntityLook format : {0}", str);
                return new ActorLook();
            }
            int i = 1;
            int num = str.IndexOf('|');
            if (num == -1)
            {
                num = str.IndexOf("}");
                if (num == -1)
                {
                    throw new System.Exception("Incorrect EntityLook format : " + str);
                }
            }
            short bones = short.Parse(str.Substring(i, num - i));
            i = num + 1;
            short[] skins = new short[0];
            if ((num = str.IndexOf('|', i)) != -1 || (num = str.IndexOf('}', i)) != -1)
            {
                skins = ActorLook.ParseCollection<short>(str.Substring(i, num - i), new Func<string, short>(short.Parse));
                i = num + 1;
            }
            Tuple<int, int>[] source = new Tuple<int, int>[0];
            if ((num = str.IndexOf('|', i)) != -1 || (num = str.IndexOf('}', i)) != -1)
            {
                source = ActorLook.ParseCollection<Tuple<int, int>>(str.Substring(i, num - i), new Func<string, Tuple<int, int>>(ActorLook.ParseIndexedColor));
                i = num + 1;
            }
            short[] scales = new short[0];
            if ((num = str.IndexOf('|', i)) != -1 || (num = str.IndexOf('}', i)) != -1)
            {
                scales = ActorLook.ParseCollection<short>(str.Substring(i, num - i), new Func<string, short>(short.Parse));
                i = num + 1;
            }
            System.Collections.Generic.List<SubActorLook> list = new System.Collections.Generic.List<SubActorLook>();
            while (i < str.Length)
            {
                int num2 = str.IndexOf('@', i, 3);
                int num3 = str.IndexOf('=', num2 + 1, 3);
                byte category = byte.Parse(str.Substring(i, num2 - i));
                byte b = byte.Parse(str.Substring(num2 + 1, num3 - (num2 + 1)));
                int num4 = 0;
                int num5 = num3 + 1;
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                do
                {
                    stringBuilder.Append(str[num5]);
                    if (str[num5] == '{')
                    {
                        num4++;
                    }
                    else
                    {
                        if (str[num5] == '}')
                        {
                            num4--;
                        }
                    }
                    num5++;
                }
                while (num4 > 0);
                list.Add(new SubActorLook((sbyte)b, (SubEntityBindingPointCategoryEnum)category, ActorLook.Parse(stringBuilder.ToString())));
                i = num5 + 1;
            }
            return new ActorLook(bones, skins, source.ToDictionary((Tuple<int, int> x) => x.Item1, (Tuple<int, int> x) => Color.FromArgb(x.Item2)), scales, list.ToArray(), isMorph);
        }
        public void RemoveColors()
        {
            m_colors = new Dictionary<int, Color>();
        }
        private static Tuple<int, int> ParseIndexedColor(string str)
        {
            int num = str.IndexOf("=");
            bool flag = str[num + 1] == '#';
            int item = int.Parse(str.Substring(0, num));
            int item2 = int.Parse(str.Substring(num + (flag ? 2 : 1), str.Length - (num + (flag ? 2 : 1))), flag ? System.Globalization.NumberStyles.HexNumber : System.Globalization.NumberStyles.Integer);
            return Tuple.Create<int, int>(item, item2);
        }
        private static T[] ParseCollection<T>(string str, Func<string, T> converter)
        {
            T[] result;
            if (string.IsNullOrEmpty(str))
            {
                result = new T[0];
            }
            else
            {
                int num = 0;
                int num2 = str.IndexOf(',', 0);
                if (num2 == -1)
                {
                    result = new T[]
                    {
                        converter(str)
                    };
                }
                else
                {
                    T[] array = new T[str.CountOccurences(',', num, str.Length - num) + 1];
                    int num3 = 0;
                    while (num2 != -1)
                    {
                        array[num3] = converter(str.Substring(num, num2 - num));
                        num = num2 + 1;
                        num2 = str.IndexOf(',', num);
                        num3++;
                    }
                    array[num3] = converter(str.Substring(num, str.Length - num));
                    result = array;
                }
            }
            return result;
        }
        public void AddColor(int index, Color color)
        {
            this.m_colors.Add(index, color);
        }
        public void SetColors(params Color[] colors)
        {
            int index = 1;
            this.m_colors = colors.ToDictionary((Color x) => index++);
        }
        public void AddSkin(short skin)
        {
            this.m_skins.Add(skin);
        }
        public void SetSkins(params short[] skins)
        {
            this.m_skins = skins.ToList<short>();
        }
        public override string ToString()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("{");
            int num = 0;
            stringBuilder.Append(this.BonesID);
            if (this.Skins == null || !this.Skins.Any<short>())
            {
                num++;
            }
            else
            {
                stringBuilder.Append("|".ConcatCopy(num + 1));
                num = 0;
                stringBuilder.Append(string.Join<short>(",", this.Skins));
            }
            if (this.Colors == null || !this.Colors.Any<System.Collections.Generic.KeyValuePair<int, Color>>())
            {
                num++;
            }
            else
            {
                stringBuilder.Append("|".ConcatCopy(num + 1));
                num = 0;
                stringBuilder.Append(string.Join(",",
                    from entry in this.Colors
                    select entry.Key + "=" + entry.Value.ToArgb()));
            }
            if (this.Scales == null || !this.Scales.Any<short>())
            {
                num++;
            }
            else
            {
                stringBuilder.Append("|".ConcatCopy(num + 1));
                num = 0;
                stringBuilder.Append(string.Join<short>(",", this.Scales));
            }
            if (this.SubLooks == null || !this.SubLooks.Any<SubActorLook>())
            {
                num++;
            }
            else
            {
                stringBuilder.Append("|".ConcatCopy(num + 1));
                stringBuilder.Append(string.Join<SubActorLook>(",",
                    from entry in this.SubLooks
                    select entry));
            }
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

      

    }
}
