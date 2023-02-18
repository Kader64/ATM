using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATM
{
    internal class UserData
    {
        public string username { get; set; }
        public int score { get; set; }

        public UserData() { }

        [JsonConstructor]
        public UserData(string username, int score)
        {
            this.username = username;
            this.score = score;
        }
    }
}
