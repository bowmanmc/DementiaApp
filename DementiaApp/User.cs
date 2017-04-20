using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;


namespace DementiaApp
{
    public class User
    {
        private Guid _id;
        private DateTime _dateCreated;
        private String _name;
        private String _email;

        public User()
        {
            _id = Guid.NewGuid();
            _dateCreated = DateTime.Now;
        }

        public String Id
        {
            get { return this._id.ToString(); }
        }

        public DateTime DateCreated
        {
            get { return this._dateCreated; }
        }

        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public String Email
        {
            get { return this._email; }
            set
            {
                if (value.Contains("@") && value.Contains("."))
                {
                    this._email = value;
                }
                else
                {
                    throw new Exception("User email must contain @ and . characters...");
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0} <{1}> - {2}", this._name, this._email, this._id);
        }

        public string ToJson()
        {
            JsonObject result = new JsonObject();
            result["id"] = JsonValue.CreateStringValue(this._id.ToString());
            result["name"] = JsonValue.CreateStringValue(this._name);
            result["dateCreated"] = JsonValue.CreateStringValue(this._dateCreated.ToString());
            result["email"] = JsonValue.CreateStringValue(this._email);
            return result.Stringify();
        }

        public static User FromJson(String jsonString)
        {
            JsonObject jsonObject = JsonObject.Parse(jsonString);
            User result = new DementiaApp.User();
            result._dateCreated = Convert.ToDateTime(jsonObject.GetNamedString("dateCreated"));
            result._id = Guid.Parse(jsonObject.GetNamedString("id"));
            result._name = jsonObject.GetNamedString("name");
            result._email = jsonObject.GetNamedString("email");
            return result;
        }
    }
}
