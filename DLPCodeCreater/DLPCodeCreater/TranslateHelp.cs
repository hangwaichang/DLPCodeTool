using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Text.RegularExpressions;
using System.Linq;

namespace DLPCodeCreater
{
    internal class TranslateHelp
    {
        //多語系彙總黨
        public List<LanguageTranslate> languageTranslates_merge { get; set; }

        public string TranslateText(string language, string tolanguage, string input)
        {
            // Set the language from/to in the url (or pass it into this function)
            string url = String.Format
            ("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
             language, tolanguage, Uri.EscapeUriString(input));
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync(url).Result;

            // Get all json data
            var jsonData = JsonConvert.DeserializeObject<List<dynamic>>(result);

            // Extract just the first array element (This is the only data we are interested in)
            var translationItems = jsonData[0];

            // Translation Data
            string translation = "";

            // Loop through the collection extracting the translated objects
            foreach (object item in translationItems)
            {
                // Convert the item array to IEnumerable
                IEnumerable translationLineObject = item as IEnumerable;

                // Convert the IEnumerable translationLineObject to a IEnumerator
                IEnumerator translationLineString = translationLineObject.GetEnumerator();

                // Get first object in IEnumerator
                translationLineString.MoveNext();

                // Save its value (translated text)
                translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
            }

            // Remove first blank character
            if (translation.Length > 1) { translation = translation.Substring(1); };

            // Return translation
            return translation;
        }

        //合併並去除重複
        public void mergeTranslate(List<LanguageTranslate> ls)
        {
            languageTranslates_merge = languageTranslates_merge.Union(ls).DistinctBy(x => x.TW).ToList();
        }

        public List<LanguageTranslate> getTranslate(FileInfo[] files)
        {
            List<LanguageTranslate> list_lt = new List<LanguageTranslate>();

            foreach (FileInfo f in files)
            {
                var lines = File.ReadAllLines(f.ToString());
                for (int i = 0; i < lines.Length; i++)
                {
                    Regex regex = new Regex(@"('|`)([^'`]*)[\u4E00-\u9FFF]+([^'`]*)('|`)");//查詢檔案名稱中有關鍵字friend的文件
                    Match m = regex.Match(lines[i]);
                    if (m.Success == true)
                    {
                        LanguageTranslate lt = getMutiTranslate(hashtagExchange(dataNormalization(m.Value), "en"));
                        list_lt.Add(lt);
                    }
                }
            }

            return list_lt;
        }

        public List<LanguageTranslate> getTranslate(string dir)
        {
            List<LanguageTranslate> list_lt = new List<LanguageTranslate>();


            var lines = File.ReadAllLines(dir.ToString());
            for (int i = 0; i < lines.Length; i++)
            {
                Regex regex = new Regex(@"('|`)([^'`]*)[\u4E00-\u9FFF]+([^'`]*)('|`)");//查詢檔案名稱中有關鍵字friend的文件
                Match m = regex.Match(lines[i]);
                if (m.Success == true)
                {
                    LanguageTranslate lt = getMutiTranslate(hashtagExchange(dataNormalization(m.Value), "en"));
                    list_lt.Add(lt);
                }
            }

            return list_lt;
        }

        /// <summary>
        /// 取得多國翻譯 zh,en,vi
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public LanguageTranslate getMutiTranslate(string input)
        {
            LanguageTranslate ltResult = new LanguageTranslate();
            ltResult.TW = hashtagExchange(input, "de");
            ltResult.ZH = dlpNormalization(hashtagExchange(TranslateText("zh-tw", "zh", input), "de"));
            ltResult.EN = dlpNormalization(hashtagExchange(TranslateText("zh-tw", "en", input), "de"));
            ltResult.VI = dlpNormalization(hashtagExchange(TranslateText("zh-tw", "vi", input), "de"));
            return ltResult;
        }

        /// <summary>
        /// 井字號轉換(#to@@)
        /// 因URL遇到#字號會截斷，所以需轉換
        /// </summary>
        /// <param name="input"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public string hashtagExchange(string input, string code)
        {
            string strResult = input;

            if (code == "en")
            {
                Regex regex = new Regex(@"\s?#\s?[NnTtSs<>&]\s?~\s?");
                Match m = regex.Match(input);
                if (m.Success == true)
                {
                    strResult = Regex.Replace(input, "#", "@@");
                }
            }
            else if (code == "de")
            {
                Regex regex = new Regex(@"\s?@@\s?[NnTtSs<>&]\s?~\s?");
                Match m = regex.Match(input);
                if (m.Success == true)
                {
                    strResult = Regex.Replace(input, "@@", "#");
                }
            }

            return strResult;

        }

        /// <summary>
        /// 自訂義正則
        /// EX:換行 (#n~)空格(#s~)縮排 (#t~)< (#<~)> (#>~)& (#&~)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string dlpNormalization(string input)
        {
            string strResult = input;

            Regex regex = new Regex(@"\s?#\s?[NnTtSs<>&]\s?~\s?");
            Match m = regex.Match(input);
            if (m.Success == true)
            {
                var newChar = Regex.Replace(m.Value, @"\s+", "");
                strResult = strResult.Replace(m.Value, newChar);
            }
            return strResult;
        }

        //資料正規化
        public string dataNormalization(string input)
        {
            string strResult = "";


            //去單引號
            if (input.StartsWith('\''))
            {
                strResult = input.TrimStart('\'').TrimEnd('\'');
            }
            if (input.StartsWith('`'))
            {
                strResult = input.TrimStart('`').TrimEnd('`');
            }


            //去除空白
            strResult = Regex.Replace(strResult, @"\s", "");

            //去重複
            //strResult = dataRepeatClear(strResult, "??");
            //strResult = dataRepeatClear(strResult, "!!");

            //符號取代
            dataRepalce(ref strResult, ':', '：');
            dataRepalce(ref strResult, ';', '；');
            //dataRepalce(ref strResult, '`', '、');
            dataRepalce(ref strResult, '?', '？');
            dataRepalce(ref strResult, '!', '！');

            dataRepalce(ref strResult, '〈', '(');
            dataRepalce(ref strResult, '〉', ')');
            //dataRepalce(ref strResult, '（', '(');
            //dataRepalce(ref strResult, '）', ')');
            //dataRepalce(ref strResult, '〔', '[');
            //dataRepalce(ref strResult, '〕', ']');
            //dataRepalce(ref strResult, '｛', '{');
            //dataRepalce(ref strResult, '｝', '}');

            dataRepalce(ref strResult, '.', '。');
            dataRepalce(ref strResult, ',', '，');

            return strResult;
        }

        public void dataRepalce(ref string input, char oldChar, char newChar)
        {
            input = input.Replace(oldChar, newChar);
        }

        public string dataRepeatClear(string input, string repeatStr)
        {
            string ressult = input;
            if (input.IndexOf(repeatStr) > 0)
            {
                dataRepeatClear(input.Replace(repeatStr, repeatStr.FirstOrDefault().ToString()), repeatStr);
            }

            return ressult;
        }
    }
}
