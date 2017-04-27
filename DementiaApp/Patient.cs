using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace DementiaApp
{
    class Patient
    {
        private Guid _id;
        private DateTime _dateCreated;
        private String _name;
        private int _age;
  
        public Patient()
        {
            _id = Guid.NewGuid();
            _dateCreated = DateTime.Now;
        }

        public String Id
        {
            get { return _id.ToString(); }
        }

        public DateTime DateCreated
        {
            get { return _dateCreated; }
        }

        public String Name
        {
            get { return _name; }
            set { this._name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { this._age = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} ({1}) - {2}", this._name, this._age, this._id.ToString());
        }

        public String ToJson()
        {
            JsonObject result = new JsonObject();
            result["id"] = JsonValue.CreateStringValue(this._id.ToString());
            result["dateCreated"] = JsonValue.CreateStringValue(this._dateCreated.ToString());
            result["name"] = JsonValue.CreateStringValue(this._name);
            result["age"] = JsonValue.CreateNumberValue(this._age);
            return result.Stringify();
        }

        public static Patient FromJson(String jsonString)
        {
            JsonObject jsonObject = JsonObject.Parse(jsonString);
            Patient result = new DementiaApp.Patient();
            result._id = Guid.Parse(jsonObject.GetNamedString("id"));
            result._dateCreated = Convert.ToDateTime(jsonObject.GetNamedString("dateCreated"));
            result._name = jsonObject.GetNamedString("name");
            result._age = (int) jsonObject.GetNamedNumber("age");
            return result;
        }
    }
}
