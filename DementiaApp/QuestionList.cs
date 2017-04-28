using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;


namespace DementiaApp
{
    class QuestionList
    {
        private List<String> _questions;
        private DateTime _dateCreated;

        public QuestionList()
        {
            _questions = new List<String>();
            _dateCreated = DateTime.Now;
        }

        public List<String> Questions
        {
            get { return this._questions; }
            set { this._questions = value; }
        }

        public String ToJson()
        {
            JsonObject result = new JsonObject();
            result["dateCreated"] = JsonValue.CreateStringValue(this._dateCreated.ToString());
            // Convert questions list to json array
            JsonArray array = new JsonArray();
            foreach (String q in this._questions)
            {
                array.Add(JsonValue.CreateStringValue(q));
            }
            result["questions"] = array;
 
            return result.Stringify();
        }

        public static QuestionList FromJson(String jsonString)
        {
            JsonObject jsonObject = JsonObject.Parse(jsonString);
            QuestionList result = new DementiaApp.QuestionList();
            result._dateCreated = Convert.ToDateTime(jsonObject.GetNamedString("dateCreated"));
            // fill out questions list with values from the
            // parsed json string...
            foreach (JsonValue jsonValue in jsonObject.GetNamedArray("questions", new JsonArray()))
            {
                result._questions.Add(jsonValue.GetString());
            }

            return result;
        }
    }
}
